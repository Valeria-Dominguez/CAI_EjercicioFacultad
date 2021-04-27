using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Excepciones
{
    public class AlumnoInexistenteException: Exception
    {
        public AlumnoInexistenteException(string message) : base(message)
        {
        }
        public AlumnoInexistenteException() : base("El alumno no existe\n")
        {
        }
    }
}
