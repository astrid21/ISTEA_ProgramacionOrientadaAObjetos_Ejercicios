using System;

namespace Unidad1Ej02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP";

            LineaV linea = new LineaV();
            linea.Largo = 10;
            linea.Imprimir();

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
