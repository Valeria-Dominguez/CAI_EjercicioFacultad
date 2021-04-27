using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    class Docente : Empleado
    {
        public Docente(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {
        }

        public override string GetNombreCompleto()
        {
            return $"Docente {Nombre}";
        }
    }
}
