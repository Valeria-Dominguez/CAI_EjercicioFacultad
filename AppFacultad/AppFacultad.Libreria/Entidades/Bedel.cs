using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    class Bedel : Empleado
    {
        string _apodo;

        public Bedel(string apodo, string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {
            _apodo = apodo;
        }
        public override string GetNombreCompleto()
        {
            return $"Bedel {this._apodo}";
        }
    }
}
