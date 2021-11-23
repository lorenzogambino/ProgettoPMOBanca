using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{

    class ContoCSV  // classe per gestire il file csv dei conti
    {
        public string proprietario { get; set; }
        public string tipo { get; set; }
        public string iban { get; set; }
        public double saldo { get; set; }
        public string listaoperazioni { get; set; }
        public int numuoperazioni { get; set; }

        public static string GeneraIban() //genera casualmente un codice di 27 caratteri
        {
            int[] niban = new int[25];
            Random randNum = new Random();
            for (int i = 0; i < niban.Length; i++)
            {
                niban[i] = randNum.Next(0, 9);
            }
            string result = string.Join("", niban);
            return "IT" + result;
        }

        public ContoCSV(string riga) //costruttore
        {
            string[] colonne = riga.Split(';');
            proprietario = colonne[0];
            tipo = colonne[1];
            iban = colonne[2];
            saldo = Convert.ToDouble(colonne[3]);
            listaoperazioni = colonne[4];
            numuoperazioni = Convert.ToInt32(colonne[5]);
        }
    }
    
    class ContiCSV : ObservableCollection<Conto> // oggetto che deriva da un observablecollection di oggeti conto 
    {                                            
        public ContiCSV() { }

        public ContiCSV(string nomeFile) 
        {

            StreamReader sr = new StreamReader(nomeFile);
            sr.ReadLine();
            SpesaMensile spesaMensile = new SpesaMensile();

            while (!sr.EndOfStream) // leggere tutto il file
            {
                Conto c;
                string riga = sr.ReadLine();
                ContoCSV contox = new ContoCSV(riga);
                //Operazione o = new Operazione("Creazione Conto", 0, DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString());
                switch (contox.tipo) // crea il conto in base al tipo
                {
                    case "Conto a Consumo":
                        c = new ContoAConsumo(contox.proprietario, contox.tipo, contox.iban, Convert.ToDouble(contox.saldo), contox.listaoperazioni);
                        //c.ListaOperazioni.Add(o);
                        Add(c);
                        break;
                    case "Conto Young":
                        c = new ContoYoung(contox.proprietario, contox.tipo, contox.iban, Convert.ToDouble(contox.saldo), false, contox.listaoperazioni,contox.numuoperazioni);
                        //c.ListaOperazioni.Add(o);
                        Add(c);
                        spesaMensile.Attach((ContoAFranchigia)c); //aggiunge il conto a franchigia alla lista dei conti a franchigia da notificare ogni mese (observer pattern)

                        break;
                    case "Conto Standard":
                        c = new ContoStandard(contox.proprietario, contox.tipo, contox.iban, Convert.ToDouble(contox.saldo), false, contox.listaoperazioni, contox.numuoperazioni);
                        //c.ListaOperazioni.Add(o);
                        Add(c);
                        spesaMensile.Attach((ContoAFranchigia)c); //aggiunge il conto a franchigia alla lista dei conti a franchigia da notificare ogni mese (observer pattern)
                        break;
                    case "Conto Business":
                        c = new ContoBusiness(contox.proprietario, contox.tipo, contox.iban, Convert.ToDouble(contox.saldo), false, contox.listaoperazioni, contox.numuoperazioni);
                        //c.ListaOperazioni.Add(o);
                        Add(c);
                        spesaMensile.Attach((ContoAFranchigia)c); //aggiunge il conto a franchigia alla lista dei conti a franchigia da notificare ogni mese (observer pattern)
                        break;
                }
                    spesaMensile.Notify(); //fa pagare le spese mensili (observer pattern)
            }
            sr.Close();
        }

        public string WriteOperazione(List<Operazione> ListaOperazioni) // converte la lista di operazioni in una stringa da scrivere sul file
        {
            string s = "";
            foreach (Operazione operazione in ListaOperazioni)
            {
                if (s == "")
                    s += operazione.ToString();
                else
                    s += "_" + operazione.ToString();
            }
            return s;
        }
        public void Writer(string nomeFile) // scrive su file tutti i conti opportunamente formattati per essere riletti
        {
            string s = "///////////////////////";
            foreach (Conto c in this)
            {
                s += "\n" + c.proprietario + ";" + c.tipoConto + ";" + c.iban + ";" + c.saldo.ToString() + ";" + WriteOperazione(c.ListaOperazioni) + ";" + c.numoperazioni.ToString();
                StreamWriter sw = new StreamWriter(nomeFile);
                sw.Write(s);
                sw.Close();
            }
        }

    }
}
