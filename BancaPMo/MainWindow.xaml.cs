using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BancaPMo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContiCSV Conti;
        int i;
        Conto c;
        public void UpdateLv()
        {
            lvConti.ItemsSource = null;
            lvConti.ItemsSource = Conti;
            Conti.Writer(@"..\Debug\Conti.csv");
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Conti = new ContiCSV(@"..\Debug\Conti.csv");
                UpdateLv();

            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }

        }

        private void BtnCreazione_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckConsumo.IsChecked == false && CheckYoung.IsChecked == false && CheckBusiness.IsChecked == false && CheckStandard.IsChecked == false)
                    MessageBox.Show("Selezionare tipo di conto da creare");
                else
                {
                    Operazione o = new Operazione("CreazioneConto", 0, DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString());
                    if (CheckConsumo.IsChecked == true)
                    {
                        c = new ContoAConsumo(txtIntestatario.Text, "Conto a Consumo", ContoCSV.GeneraIban(), 0, "");                       
                        c.ListaOperazioni.Add(o);
                        Conti.Add(c);
                    }
                    if (CheckYoung.IsChecked == true)
                    {
                        c = new ContoYoung(txtIntestatario.Text, "Conto Young", ContoCSV.GeneraIban(), 0, true, "", 0);
                        c.ListaOperazioni.Add(o);
                        Conti.Add(c);
                    }
                    if (CheckBusiness.IsChecked == true)
                    {
                        c = new ContoBusiness(txtIntestatario.Text, "Conto Business", ContoCSV.GeneraIban(), 0, true, "", 0);
                        c.ListaOperazioni.Add(o);
                        Conti.Add(c);
                    }
                    if (CheckStandard.IsChecked == true)
                    {
                        c = new ContoStandard(txtIntestatario.Text, "Conto Standard", ContoCSV.GeneraIban(), 0, true, "", 0);
                        c.ListaOperazioni.Add(o);
                        Conti.Add(c);
                    }

                    UpdateLv();
                    MessageBox.Show("Conto creato correttamente");
                    AttivaSchedeOperazioni();
                    outEsito1.Text = outEsito2.Text = outEsito3.Text = outEsito4.Text = outSaldo1.Text = outSaldo2.Text = txtDestinatario.Text = txtImporto1.Text = txtImporto2.Text = txtImporto3.Text = txtIntestatario.Text = outSaldo3.Text = ""; //pulisce tutte i dati inseriti
                }

            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }

        }
        private void BtnVersamento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outEsito1.Text = c.Versamento(Convert.ToDouble(txtImporto1.Text));
                outSaldo1.Text = outSaldo2.Text = c.saldo.ToString();
                UpdateLv();
            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }
        }

        private void BtnPrelievo_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                outEsito2.Text = c.Prelievo(Convert.ToDouble(txtImporto2.Text));
                outSaldo2.Text = outSaldo1.Text = c.saldo.ToString();
                UpdateLv();
            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }
        }

        private void BtnBonifico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                outEsito3.Text = c.Bonifico(Conti, Convert.ToDouble(txtImporto3.Text), txtDestinatario.Text);
                outSaldo3.Text = outSaldo1.Text = outSaldo2.Text = c.saldo.ToString();
                UpdateLv();
            }
            catch (Exception Erore)
            {
                MessageBox.Show(Erore.Message);
            }
        }

        private void BtnMovimenti_Click(object sender, RoutedEventArgs e)
        {
            outEsito4.Text = c.GetEstratto();
        }

        private void LvConti_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvConti.SelectedItems.Count == 1)
            {
                i = lvConti.SelectedIndex;
                c = Conti[i];
                outSaldo3.Text = outSaldo1.Text = outSaldo2.Text = c.saldo.ToString();
                AttivaSchedeOperazioni();
                outEsito1.Text = outEsito2.Text = outEsito3.Text = outEsito4.Text = outSaldo1.Text = outSaldo2.Text = txtDestinatario.Text = txtImporto1.Text=txtImporto2.Text=txtImporto3.Text=txtIntestatario.Text = outSaldo3.Text = ""; //pulisce tutte i dati inseriti
            }
        }
        private void AttivaSchedeOperazioni()
        {
            TabBonifico.IsEnabled = true;
            TabVersamento.IsEnabled = true;
            TabMovimenti.IsEnabled = true;
            TabPrelievo.IsEnabled = true;            
            TabVersamento.IsSelected = true;
        }
        
        private void ControlloLettere(KeyEventArgs e)
        {
            //permette lettere spazi
            bool isLetter = e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.A && e.Key <= Key.Z && e.KeyboardDevice.Modifiers == ModifierKeys.Shift);
            bool isSpace = e.Key == Key.Space;
            bool isBack = e.Key == Key.Back;
            if (!isLetter && !isBack && !isSpace)
                e.Handled = true;
        }
        private void ControlloNumeri(KeyEventArgs e)
        {
            //permette numeri e virgole
            bool isNumber = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            bool isBack = e.Key == Key.Back;
            bool isComma = e.Key == Key.OemComma;
            if (!isNumber && !isBack && !isComma)
                e.Handled = true;
        }
        private void txtIntestatario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ControlloLettere(e);
        }

        private void txtImporto1_KeyDown(object sender, KeyEventArgs e)
        {
            ControlloNumeri(e);
        }

        private void txtImporto2_KeyDown(object sender, KeyEventArgs e)
        {
            ControlloNumeri(e);
        }

        private void txtImporto3_KeyDown(object sender, KeyEventArgs e)
        {
            ControlloNumeri(e);
        }
    }
}
