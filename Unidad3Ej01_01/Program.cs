using System;

namespace Unidad3Ej01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantEmpleados = 3;
            Empleado[] Empleados = new Empleado[cantEmpleados];
            int posSueldoMayor;
            for (int i = 0; i < Empleados.Length; i++)
            {
                Empleado empleado = new Empleado();
                empleado.Nombre = Validaciones.ValidarNombre();
                empleado.Sueldo = Validaciones.ValidarSueldo(empleado.Nombre);
                Empleados[i] = empleado;
                Console.WriteLine("---------------------------------------------------------");
            }

            posSueldoMayor = BuscarSueldoMayor(Empleados);
            Console.WriteLine($"El sueldo mas elevado es de {Empleados[posSueldoMayor].Sueldo} y perteneces" +
                $"a {Empleados[posSueldoMayor].Nombre}");
            Console.ReadKey();
           
        }


        public static int BuscarSueldoMayor(Empleado[] arrayEmpleados)
        {
            int posSueldoMayor = 0;
            int sueldoMayor = 0;
            for (int i = 0; i < arrayEmpleados.Length; i++)
            {
                if(arrayEmpleados[i].Sueldo > sueldoMayor)
                {
                    sueldoMayor = arrayEmpleados[i].Sueldo;
                    posSueldoMayor = i;

                }
            }

            return posSueldoMayor;
        }
    }
}
