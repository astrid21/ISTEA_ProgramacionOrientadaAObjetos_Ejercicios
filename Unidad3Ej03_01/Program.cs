using System;
using System.Collections;
using System.Collections.Generic;

namespace Unidad3Ej03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();

            bool continuar = true;
            do
            {
                ConsoleKeyInfo teclaLeida = MostrarMenu();
                switch (teclaLeida.Key)
                {
                    case ConsoleKey.Add:
                        AgregarEmpleado(empleados);
                        break;
                    case ConsoleKey.Subtract:
                        EliminarEmpleado(empleados);
                        break;
                    case ConsoleKey.Enter:
                        EscribirEmpleado(empleados);
                        break;
                    case ConsoleKey.Escape:
                        continuar = false;        //Finaliza la aplicacion.
                        break;
                }
            } while (continuar);


        }

        public static ConsoleKeyInfo MostrarMenu()
        {
            Console.Clear();

            Console.WriteLine("Tecla + : Adicionar un nuevo empleado.");
            Console.WriteLine("Tecla - : Eliminar un empleado.");
            Console.WriteLine("Tecla Enter : Listar empleados.");
            Console.WriteLine("Tecla Esc : Salir.");

            ConsoleKeyInfo teclaLeida = Console.ReadKey(false);

            return teclaLeida;
        }

        public static void AgregarEmpleado(List<Empleado> empleados)
        {
            string nombre;
            int sueldo;
            Empleado empleado = new Empleado();
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("Error, nombre no valido");
            }
            empleado.Nombre = nombre;
            Console.Write("Sueldo: ");
            if (!int.TryParse(Console.ReadLine(), out sueldo) || sueldo < 1)
            {
                throw new Exception("Error, sueldo no valido");
            }
            empleado.Sueldo = sueldo;

            empleados.Add(empleado);
        }

        public static void EliminarEmpleado(List<Empleado> empleados)
        {
            string nombre;
            Console.Write("Nombre del empleado a eliminar: ");
            nombre = Console.ReadLine();
            bool encontrado = false;
            Empleado ParaEliminar = new Empleado();
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre == nombre)
                {
                    ParaEliminar = empleado;

                    encontrado = true;

                }
            }

            if (encontrado == false)
            {
                Console.WriteLine($"{nombre} no fue encontrado en la lista de empleados");
            }
            else
            {
                empleados.Remove(ParaEliminar);
                Console.WriteLine($"{nombre} fue eliminado");
            }

            Console.ReadKey();

        }

        public static void EscribirEmpleado(List<Empleado> empleados)
        {
            Console.WriteLine("Nombre    | Sueldo");
            foreach (Empleado emp in empleados)
            {
                Console.WriteLine($"{emp.Nombre,-10 }| {emp.Sueldo}");
            }
            Console.WriteLine("presione cualquier tecla para volver al menu");
            Console.ReadKey();
        }
    }
}
