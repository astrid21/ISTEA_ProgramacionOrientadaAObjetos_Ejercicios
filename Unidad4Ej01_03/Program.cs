using System;

namespace Unidad4Ej01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpleadoContratado empleadoContratado = new EmpleadoContratado(1111, 2222);
            empleadoContratado.Imprimir();

            Console.ReadLine();
        }
    }
}
