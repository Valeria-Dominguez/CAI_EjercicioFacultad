using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Excepciones
{
    public class EmpleadoInexistenteException : Exception
    {
        public EmpleadoInexistenteException(string message) : base(message)
        {
        }
        public EmpleadoInexistenteException() : base("El empleado no existe\n")
        {
        }
    }
}
