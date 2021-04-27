using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Excepciones
{
    public class TipoEmpleadoInvalidoException : Exception
    {
        public TipoEmpleadoInvalidoException(string message) : base(message)
        {
        }
        public TipoEmpleadoInvalidoException() : base("Tipo de empleado inválido\n")
        {
        }
    }
}
