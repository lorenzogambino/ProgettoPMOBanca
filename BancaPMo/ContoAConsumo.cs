using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{ 
    class ContoAConsumo : Conto
    {
        public ContoAConsumo(string _proprietario, string _tipo, string _iban, double _saldo, string _strOperazioni)
        {
            this.proprietario = _proprietario;
            this.tipoConto = _tipo;
            this.iban = _iban;
            this.saldo = _saldo;
            this.ListaOperazioni = Operazione.ToOperazione(_strOperazioni);
            this.dataCreazione = Convert.ToString(DateTime.Today);
        }

        public override string Bonifico(ContiCSV Conti, double importo, string destinatario)
        {
            bool found=false;
            string esito;
            int j=0;
            if (saldo >= importo + 1)
            {
                for(int i = 0; i < Conti.Count; i++)
                {
                    if (destinatario == Conti[i].iban)
                    {
                        j = i;
                        found = true;
                    }
                }
                if (found == false)
                    esito = "Iban non valido";
                else
                {
                    saldo = saldo - importo - 1;
                    esito = "Hai inviato un bonifico di € " + importo + " a " + destinatario;
                    string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                    ListaOperazioni.Add(new Operazione("Bonifico-", importo + 1, data));
                    RiceviBonifico(Conti[j], importo);
                }
            }
            else
                esito = "Saldo non sufficiente";
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
            if (saldo >= importo + 1)
            {
                saldo = saldo - importo - 1;
                esito = "Hai prelevato " + (importo-1) + " €";
                string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                ListaOperazioni.Add(new Operazione("Prelievo-", importo-1, data));
            }
            else
                esito = "Saldo non sufficiente";
            return esito;
        }

        public override void RiceviBonifico(Conto c, double importo)
        {
            c.saldo += importo;
            string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

            c.ListaOperazioni.Add(new Operazione("Bonifico+", importo, data));
        }

        public override string Versamento(double importo)
        {
            string esito = "Hai versato " + (importo-1) + " €";
            saldo += importo-1;
            string data = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

            ListaOperazioni.Add(new Operazione("Versamento+", importo-1, data));
            return esito;
        }
    }
}