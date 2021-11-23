using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaPMo
{
    class ContoBusiness : ContoAFranchigia
    {
        public ContoBusiness(string _proprietario, string _tipo, string _iban, double _saldo, bool _primaoperazione, string _strOperazioni, int _numoperazioni)
        {
            this.proprietario = _proprietario;
            this.tipoConto = _tipo;
            this.iban = _iban;
            this.saldo = _saldo;
            this.primaoperazione = _primaoperazione;
            this.maxoperazioni = 2147483647; // illimitate (int32 più grande possibile)
            this.spesafissa = 50;
            this.ListaOperazioni = Operazione.ToOperazione(_strOperazioni);
            this.dataCreazione = Convert.ToString(DateTime.Today);
            this.numoperazioni = _numoperazioni;
        }
    }
}