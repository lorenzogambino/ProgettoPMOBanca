using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    // The 'Subject' abstract class
    abstract class SpeseMensili // spese mensili
    {
        private List<ContoAFranchigia> ListaContiF = new List<ContoAFranchigia>(); //lista dei conti
                                                                                 
        public SpeseMensili()
        {
        }
        public void Attach(ContoAFranchigia conto)
        {
            ListaContiF.Add(conto);
        }
        public void Detach(ContoAFranchigia conto)
        {
            ListaContiF.Add(conto);
        }
        public void Notify()
        {

            foreach (ContoAFranchigia contox in ListaContiF)
            {
                Operazione op = contox.ListaOperazioni.Last();
                if (op.data.Substring(3, 2) != DateTime.Now.Month.ToString()) // se il mese dell'ultima operazione è diverso da quello corrente
                {
                    contox.numoperazioni = 0;
                    contox.primaoperazione = true;
                }
            }
        }

        
    }

    // The 'ConcreteSubject' class
    class SpesaMensile : SpeseMensili
    {
        public SpesaMensile()// costruttore
        {

        }
    }

}