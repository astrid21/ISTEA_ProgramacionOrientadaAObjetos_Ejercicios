using System;
namespace Unidad3Ej01_01
{
    static class Validaciones
    {
        public static string ValidarNombre()
        {
            string nombre;
            Console.Write("Ingrese el nombre del empleado: ");
            nombre = Console.ReadLine();
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("Error, nombre  no valido");
            }
            return nombre;
        }

        public static int ValidarSueldo(string nombre)
        {
            int sueldo;
            Console.Write("Ingrese el  sueldo de " + nombre + ": ");
            if (!int.TryParse(Console.ReadLine(), out sueldo) || sueldo < 1)
            {
                throw new Exception("Error, el sueldo debe ser un numero y no puede ser negativo");
            }

            return sueldo;
        }
    }
}
