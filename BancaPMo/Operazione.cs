using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    class Operazione // oggetto che descrive un operazione bancaria
    {

        public string tipo { get; set; }
        public double importo { get; set; }
        public string data { get; set; }

        public Operazione()
        {

        }
        public Operazione(string _tipo, double _importo, string _data)
        {
            tipo = _tipo;
            importo = _importo;
            data = _data;
        }
        public override string ToString()
        {
            return tipo + " " + importo.ToString() + " " + data;
        }
        

        
        static public List<Operazione> ToOperazione(string s) //converte la lunga stringa di operazioni da file in una lista di oggetti operazione
        {
            List<Operazione> ListaOperazioni = new List<Operazione>();
            if (s != "")
            {
                string[] a = s.Split('_');
                string[] b = new string[a.Length * 3];
                string[] temp;
                int j = 0;
                int i = 0;
                int k = 0;
                while (i < a.Length)
                {
                    temp = a[i].Split(' ');
                    i++;
                    while (k < 3)
                    {
                        b[j] = temp[k];
                        j++;
                        k++;
                    }
                    k = 0;
                }
                k = 2;
                i = 1;
                j = 0;
                while (j < b.Length)
                {
                    ListaOperazioni.Add(new Operazione(b[j], Convert.ToDouble(b[i]), b[k]));
                    i += 3;
                    j += 3;
                    k += 3;
                }
            }
            return ListaOperazioni;
        }
    }
}
