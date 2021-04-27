using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    sealed class Directivo : Empleado
    {
        public Directivo(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {
        }
        public override string GetNombreCompleto()
        {
            return $"Sr. Director {Apellido}";
        }
    }
}
