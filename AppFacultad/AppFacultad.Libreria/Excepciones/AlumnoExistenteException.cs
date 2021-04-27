using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Excepciones
{
    public class AlumnoExistenteException:Exception
    {
        public AlumnoExistenteException(string message) : base (message)
        {
        }
        public AlumnoExistenteException () : base ("El alumno ya existe\n")
        {
        }
    }
}
