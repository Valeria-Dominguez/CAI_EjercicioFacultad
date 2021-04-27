using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    public abstract class Empleado : Persona
    {
        DateTime _fechaIngreso;
        int _legajo;
        List<Salario> _salarios;

        public DateTime FechaIngreso { get => _fechaIngreso; }
        public int Legajo { get => _legajo; }
        public List<Salario> Salarios { get => _salarios; }
        public Salario UltimoSalario
        {
            get
            {
                return this._salarios.Last();
            }
        }
        public int Antiguedad
        {
            get
            {
                int antiguedad;
                TimeSpan lapso = this._fechaIngreso - DateTime.Today;
                int dias = (int)lapso.Days;
                antiguedad = dias / 365 - dias % 365;
                return antiguedad;
            }
        }

        internal Empleado(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre)
        {
            _fechaIngreso = fechaIngreso;
            _legajo = legajo;
            _salarios = new List<Salario>();
        }

        public override string GetNombreCompleto()
        {
            return base.GetNombreCompleto();
        }

        public override string GetCredencial()
        {
            return $"{Legajo} - {GetNombreCompleto()} salario $ {UltimoSalario.GetSalarioNeto()}";
        }

        public override string ToString()
        {
            return GetCredencial();
        }

        internal protected void AgregarSalario (Salario salario)
        {
            this.Salarios.Add(salario);
        }

        public override bool Equals(object obj)
        {
            bool igual = false;
            Empleado empleado = (Empleado)obj;
            if(this._legajo == empleado.Legajo)
            {
                igual = true;
            }
            return igual;
        }


    }
}
