using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    public abstract class Persona
    {
        string _apellido;
        DateTime _fechaNac;
        string _nombre;

        public string Apellido { get => _apellido; }
        public  string Nombre { get => _nombre; }
        public DateTime FechaNac { get => _fechaNac; }
        public int Edad
        {
            get
            {
                int edad;
                TimeSpan lapso = (this._fechaNac - DateTime.Today);
                int dias = (int)lapso.TotalDays;
                edad = dias / 365 - dias % 365;
                return edad;
            }
        }

        protected Persona(string apellido, DateTime fechaNac, string nombre)
        {
            _apellido = apellido;
            _fechaNac = fechaNac;
            _nombre = nombre;
        }

        public abstract string GetCredencial();

        public virtual string GetNombreCompleto()
        {
            return $"{this._nombre} {this._apellido}";
        }
    }
}
