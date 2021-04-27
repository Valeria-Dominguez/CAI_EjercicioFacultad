using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFacultad.Libreria.Entidades
{
    public class Facultad
    {
        List<Alumno> _alumnos;
        int _cantidadSedes;
        List<Empleado> _empleados;
        string _nombre;
        int _generadorCodigo;
        int _generadorLegajo;

        public Facultad(int cantidadSedes, string nombre)
        {
            this._cantidadSedes = cantidadSedes;
            this._nombre = nombre;
            this._alumnos = new List<Alumno>();
            this._empleados = new List<Empleado>();
            this._generadorCodigo = 0;
            this._generadorLegajo = 0;

        }

        public int CantidadSedes { get => _cantidadSedes; }
        public string Nombre { get => _nombre; }


        public string AgregarAlumno(string nombre, string apellido, DateTime fechaNac)
        {
            this._generadorCodigo++;

            Alumno alumno = new Alumno(this._generadorCodigo, apellido, fechaNac, nombre);
            AgregarAlumno(alumno);

            return $"Alumno ingresado con éxito. Número de código: {this._generadorCodigo.ToString()}\n";
        }

        internal void AgregarAlumno(Alumno alumno)
        {
            _alumnos.Add(alumno);
        }


        public string AgregarEmpleado(int tipoEmpleado, string apodo, string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso)
        {
            this._generadorLegajo++;
            Empleado empleado = null;

            if (tipoEmpleado==1) //Bedel
            {
                empleado = new Bedel(apodo, apellido, fechaNac, nombre, fechaIngreso, this._generadorLegajo);
            }
            else if (tipoEmpleado==2) //Docente
            {
                empleado = new Docente(apellido, fechaNac, nombre, fechaIngreso, this._generadorLegajo);
            }
            else if (tipoEmpleado==3) //Directivo
            {
                empleado = new Directivo(apellido, fechaNac, nombre, fechaIngreso, this._generadorLegajo);
            }

            AgregarEmpleado(empleado);

            return $"Empleado ingresado con éxito. Número de legajo: {this._generadorLegajo.ToString()}\n";
        }

        internal void AgregarEmpleado (Empleado empleado)
        {
            _empleados.Add(empleado);
        }


        public void EliminarAlumno (int codigo)
        {
            Alumno valor = null;
            foreach(Alumno alumno in this._alumnos)
            {
                if(alumno.Codigo==codigo)
                {
                    valor = alumno;
                }
            }
            if(valor==null)
            {
                throw new Excepciones.AlumnoInexistenteException();
            }
            EliminarAlumno(valor);
        }
        private void EliminarAlumno(Alumno alumno)
        {
            this._alumnos.Remove(alumno);
        }


        public void EliminarEmpleado (int legajo)
        {
            Empleado valor = null;
            foreach (Empleado empleado in this._empleados)
            {
                if (empleado.Legajo==legajo)
                {
                    valor = empleado;
                }
            }
            if(valor==null)
            {
                throw new Excepciones.EmpleadoInexistenteException();
            }
            EliminarEmpleado(valor);
        }

        internal void EliminarEmpleado (Empleado empleado)
        {
            this._empleados.Remove(empleado);
        }


        //Cambié de lista a string para restringir el nivel de visibilidad de alumnos
        public string TraerAlumnos()
        {
            if (this._alumnos.Count==0)
            {
                return "No hay alumnos ingresados\n";
            }
            else
            {
                string listadoAlumnos = "";
                foreach (Alumno alumno in this._alumnos)
                {
                    listadoAlumnos = listadoAlumnos + alumno.ToString() + "\n";
                }
                return listadoAlumnos;
            }
        }


        //Cambié de lista a string para restringir el nivel de visibilidad de empleados
        public string TraerEmpleados()
        {
            if (this._empleados.Count == 0)
            {
                return "No hay empleados ingresados\n";
            }
            else
            {
                string listadoEmpleados = "";
                foreach (Empleado empleado in this._empleados)
                {
                    listadoEmpleados = listadoEmpleados + empleado.ToString() + "\n";
                }
                return listadoEmpleados;
            }
        }


        //Cambié de lista a string para restringir el nivel de visibilidad de empleados
        public string TraerEmpleadoPorLegajo (int legajo)
        {
            Empleado valor = null;
            foreach (Empleado empleado in this._empleados)
            {
                if (empleado.Legajo == legajo)
                {
                    valor = empleado;
                }
            }
            if (valor == null)
            {
                throw new Excepciones.EmpleadoInexistenteException();
            }
            return valor.ToString();
        }


        //Cambié de lista a string para restringir el nivel de visibilidad de empleados
        public string TraerEmpleadosPorNombre (string nombre)
        {
            string valor = "";
            foreach (Empleado empleado in this._empleados)
            {
                if (empleado.Nombre == nombre)
                {
                    valor = valor + empleado.ToString() + "\n";
                }
            }
            if (valor == "")
            {
                throw new Excepciones.EmpleadoInexistenteException("No existen empleados con ese nombre\n");
            }
            return valor;
        }


    }
}

