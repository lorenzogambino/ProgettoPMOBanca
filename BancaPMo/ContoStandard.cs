using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    class ContoStandard : ContoAFranchigia
    {
        public ContoStandard(string _proprietario, string _tipo, string _iban, double _saldo, bool _primaoperazione, string _strOperazioni, int _numoperazioni)
        {
            this.proprietario = _proprietario;
            this.tipoConto = _tipo;
            this.iban = _iban;
            this.saldo = _saldo;
            this.primaoperazione = _primaoperazione;
            this.maxoperazioni = 30; 
            this.spesafissa = 15;
            this.ListaOperazioni = Operazione.ToOperazione(_strOperazioni);
            this.dataCreazione = Convert.ToString(DateTime.Today);
            this.numoperazioni = _numoperazioni;
        }

    }
}