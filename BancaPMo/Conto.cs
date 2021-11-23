using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    abstract class Conto // classe astratta "madre" di tutti gli altri tipi di conto
    {
        public string tipoConto
        {
            get;
            set;
        }

        public double saldo
        {
            get;
            set;
        }

        public string proprietario
        {
            get;
            set;
        }

        public string iban
        {
            get;
            set;
        }

        public string dataCreazione
        {
            get;
            set;
        }

        public int numoperazioni;

        public List<Operazione> ListaOperazioni = new List<Operazione>();
       

        public abstract string Bonifico(ContiCSV Conti,double importo, string destinatario);
        public abstract string Prelievo(double importo);
        public abstract string Versamento(double importo);
        public abstract string GetEstratto();
        public abstract void RiceviBonifico(Conto c, double importo);

    }
}