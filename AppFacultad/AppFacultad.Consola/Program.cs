using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFacultad.Libreria.Entidades;
using Validaciones;
using AppFacultad.Libreria.Excepciones;

namespace AppFacultad.Consola
{
    class Program
    {
        static Facultad miFacultad;
        
        static void Main(string[] args)
        {
            miFacultad = new Facultad(1, "Nombre Facultad");
            MenuPrincipal();

            void MenuPrincipal()
            {
                string opcion = "";
                const string opABM = "1";
                const string opListar = "2";
                const string opSalir = "3";
                do
                {
                    opcion = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción:\n" + 
                        opABM + ". ABM\n" + 
                        opListar + "Listar\n" +
                        opSalir + ". Salir\n" 
                        );
                }
                while (opcion != opSalir);

                switch (opcion)
                {
                    case opABM:
                        MenuABM();
                        break;
                    case opListar:
                        MenuListar(miFacultad);
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }

            void MenuABM()
            {
                string opcion = "";
                const string opAgregarAlumno = "1"; 
                const string opAgregarEmpleado = "2";
                const string opELiminarAlumno = "3"; 
                const string opELiminarEmpleado = "4";
                const string opModificarEmpleado = "5";

                opcion = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción:\n" +
                        opAgregarAlumno + ". Agregar alumno\n" +
                        opAgregarEmpleado + ". Agregar empleado\n" +
                        opELiminarAlumno + ". Eliminar alumno\n" +
                        opELiminarEmpleado + ". Eliminar empleado\n" +
                        opModificarEmpleado + "Modificar empleado\n" 
                        );

                switch (opcion)
                {
                    case opAgregarAlumno:
                        AgregarAlumno(miFacultad);
                        break;
                    case opAgregarEmpleado:
                        try
                        {
                            AgregarEmpleado(miFacultad);
                        }
                        catch (TipoEmpleadoInvalidoException tipoEmpleadoInvalidoExcep)
                        {
                            Console.WriteLine(tipoEmpleadoInvalidoExcep.Message);
                        }
                        break;
                    case opELiminarAlumno:
                        try
                        {
                            EliminarAlumno(miFacultad);
                        }
                        catch (AlumnoInexistenteException alumnoInexistenteExcep)
                        {
                            Console.WriteLine(alumnoInexistenteExcep.Message);
                        }
                        break;
                    case opELiminarEmpleado:
                        try
                        {
                            EliminarEmpleado(miFacultad);
                        }
                        catch (EmpleadoInexistenteException empleadoInexistenteExcep)
                        {
                            Console.WriteLine(empleadoInexistenteExcep.Message);
                        }
                        break;
                    case opModificarEmpleado:
                        ;
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

            }

            void MenuListar(Facultad facultad)
            {
                string opcion = "";
                const string opTraerAlumnos = "1";
                const string opTraerEmpleadoPorLegajo = "2";
                const string opTraerEmpleados = "3";
                const string opTraerEmpleadosPorNombre = "4";

                opcion = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción:\n" +
                        opTraerAlumnos + ". Traer alumnos\n" +
                        opTraerEmpleadoPorLegajo + ". Traer empleado por legajo\n" +
                        opTraerEmpleados + ". Traer empleados\n" +
                        opTraerEmpleadosPorNombre + ". Traer empleados por nombre\n" 
                        );

                switch (opcion)
                {
                    case opTraerAlumnos:
                        Console.WriteLine(facultad.TraerAlumnos());
                        break;
                    case opTraerEmpleadoPorLegajo:
                        try
                        {
                            TraerEmpleadoPorLegajo(facultad);
                        }
                        catch (EmpleadoInexistenteException empleadoInexistenteExcep)
                        {
                            Console.WriteLine(empleadoInexistenteExcep.Message);
                        }
                        break;
                    case opTraerEmpleados:
                        Console.WriteLine(facultad.TraerEmpleados());
                        break;
                    case opTraerEmpleadosPorNombre:
                        try
                        {
                            TraerEmpleadosPorNombre(facultad);
                        }
                        catch (EmpleadoInexistenteException empleadoInexsistenteExcep)
                        {
                            Console.WriteLine(empleadoInexsistenteExcep.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

            }

            void AgregarAlumno(Facultad facultad)
            {
                string nombre = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre del alumno");
                string apellido = Validaciones.Validaciones.ValidarStrNoVac("Ingrese apellido del alumno");
                DateTime fechaNac = Validaciones.Validaciones.PedirFecha("Ingrese fecha de nacimiento");
                Console.WriteLine(facultad.AgregarAlumno(nombre, apellido, fechaNac));
            }


            void AgregarEmpleado(Facultad facultad)
            {
                int tipoEmpleado;

                tipoEmpleado = (int)Validaciones.Validaciones.ValidarUint("Ingrese tipo de empleado:\n1.Bedel\n2.Docente\n3.Directivo");
                if (tipoEmpleado != 1 && tipoEmpleado != 2 && tipoEmpleado != 3)
                {
                    throw new TipoEmpleadoInvalidoException();
                }

                string apodo = "";
                if (tipoEmpleado==1)
                {
                    apodo = Validaciones.Validaciones.ValidarStrNoVac("Ingrese apodo del empleado");
                }

                string nombre = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre del empleado");
                string apellido = Validaciones.Validaciones.ValidarStrNoVac("Ingrese apellido del empleado");
                DateTime fechaNac = Validaciones.Validaciones.PedirFecha("Ingrese fecha de empleado");
                DateTime fechaIngreso = Validaciones.Validaciones.PedirFecha("Ingrese fecha de empleado");
                Console.WriteLine(facultad.AgregarEmpleado(tipoEmpleado, apodo, apellido, fechaNac, nombre, fechaIngreso));
            }

            void EliminarAlumno (Facultad facultad)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código del alumno");
                facultad.EliminarAlumno(codigo);
            }

            void EliminarEmpleado (Facultad facultad)
            {
                int legajo = (int)Validaciones.Validaciones.ValidarUint("Ingrese número de legajo del empleado");
                facultad.EliminarEmpleado(legajo);
            }

            void TraerEmpleadoPorLegajo (Facultad facultad)
            {
                int legajo = (int)Validaciones.Validaciones.ValidarUint("Ingrese número de legajo del empleado");
                Console.WriteLine(facultad.TraerEmpleadoPorLegajo(legajo));
            }

            void TraerEmpleadosPorNombre (Facultad facultad)
            {
                string nombre = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre del empleado");
                Console.WriteLine(facultad.TraerEmpleadosPorNombre(nombre));                
            }

        }
    }
}
