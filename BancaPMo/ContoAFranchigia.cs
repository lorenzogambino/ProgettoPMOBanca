using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    class ContoAFranchigia : Conto
    {
        public int spesafissa { get; set; }
        public int maxoperazioni { get; set; }
        public bool primaoperazione { get; set; }

        public override string Bonifico(ContiCSV Conti,double importo, string destinatario)
        {
            bool found = false;
            string esito;
            int j = 0;
            if (numoperazioni < maxoperazioni) //controllo da fare per ogni operazione nei conti a franchigia   
            {
                if (saldo >= importo)
                {
                    for (int i = 0; i < Conti.Count; i++) //cicla tutta la lista di conti
                    {
                        if (destinatario == Conti[i].iban)
                        {
                            j = i;
                            found = true; //iban valido procede con il bonifico
                        }
                    }
                    if (found == false)
                        esito = "Iban non valido";
                    else
                    {
                        saldo -= importo;
                        numoperazioni++;
                        esito = "Hai inviato un bonifico di € " + importo + " a " + destinatario;
                        string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

                        ListaOperazioni.Add(new Operazione("Bonifico-", importo, data));
                        RiceviBonifico(Conti[j], importo);
                    }
                }
                else
                    esito = "Saldo non sufficiente";
            }
            else esito = "Numero massimo di operazioni raggiunte";           
            return esito;
        }

        public override string GetEstratto()
        {
            string estratto = "";
            for (int i = 0; i < ListaOperazioni.Count; i++)
            {
                estratto += ListaOperazioni[i].ToString() + "\n";
            }
            estratto += "Saldo Attuale " + saldo.ToString() + " €";
            return estratto;
        }

        public override string Prelievo(double importo)
        {
            string esito;
            if (numoperazioni < maxoperazioni)
            {
                if (saldo >= importo)
                {
                    saldo -= importo;
                    esito = "Hai prelevato " + importo + " €";
                    string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                    numoperazioni++;
                    ListaOperazioni.Add(new Operazione("Prelievo-", importo,data));
                }
                else
                    esito = "Saldo non sufficiente";
            }
            else 
                esito = "Numero massimo di operazioni raggiunte";
            return esito;
        }
        public override void RiceviBonifico(Conto c, double importo)
        {
            c.saldo += importo;
            string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

            c.ListaOperazioni.Add(new Operazione("Bonifico+", importo,data));
        }


        public override string Versamento(double importo)
        {
            string esito;
            if (numoperazioni < maxoperazioni)
            {
                if (primaoperazione == true)
                {
                    if (importo < spesafissa) // il primo importo versato o il saldo attuale deve essere maggiore della spesa fissa mensile da detrarre
                    {
                        esito = "Versa almeno " + spesafissa.ToString() + " per la detrazione delle spese";
                    }
                    else
                    {
                        saldo += importo - spesafissa;
                        esito = "Hai versato " + importo;
                        string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                        ListaOperazioni.Add(new Operazione("Versamento+", importo, data));
                        ListaOperazioni.Add(new Operazione("Detrazione:spese-", spesafissa, data));
                        primaoperazione = false;
                        numoperazioni++;
                    }
                }
                else
                {
                    saldo += importo;
                    esito = "Hai versato " + importo + " €";
                    string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                    numoperazioni++;
                    ListaOperazioni.Add(new Operazione("Versamento+", importo, data));
                }
            }
            else
                esito = "Numero massimo di operazioni raggiunte";
            return esito;
        }
    }
}