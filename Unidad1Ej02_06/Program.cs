using System;

namespace Unidad1Ej02_06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP";
            Cuadrado cuadrado = new Cuadrado();
            cuadrado.Lado = 5;
            cuadrado.Imprimir();
            Console.WriteLine("Presione cualqueir tecla para continuar");
            Console.ReadKey();
        }
    }
}
