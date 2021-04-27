using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    public class Salario
    {
        double _bruto;
        string _codigoTransferencia;
        double _descuentos;
        DateTime _fecha;

        double Bruto { get => _bruto; }
        public string CodigoTransferencia { get => _codigoTransferencia; }
        public double Descuentos { get => _descuentos; }
        public DateTime Fecha { get => _fecha; }

        public Salario(double bruto, string codigoTransferencia, double descuentos, DateTime fecha)
        {
            this._bruto = bruto;
            this._codigoTransferencia = codigoTransferencia;
            this._descuentos = descuentos;
            this._fecha = fecha;
        }

        internal double GetSalarioNeto ()
        {
            return this.Bruto * (1 - this.Descuentos);
        }
        
        public void Salariob (double salario)
        {
            this._bruto = salario;
        }
        

    }
}
