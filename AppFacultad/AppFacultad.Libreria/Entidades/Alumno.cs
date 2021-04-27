using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    public class Alumno: Persona
    {
        int _codigo;

        public int Codigo { get => _codigo; }

        public Alumno(int codigo, string apellido, DateTime fechaNac, string nombre) : base(apellido, fechaNac, nombre)
        {
            this._codigo = codigo;
        }

        public override string GetCredencial()
        {
            return $"Código {this.Codigo}) {this.Apellido}, {this.Nombre}";
        }

        public override string ToString()
        {
            return GetCredencial();
        }

    }
}
