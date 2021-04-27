using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Excepciones
{
    public class EmpleadoExistenteException : Exception
    {
        public EmpleadoExistenteException(string message) : base(message)
        {
        }
        public EmpleadoExistenteException() : base("El empleado ya existe\n")
        {
        }
    }
}
