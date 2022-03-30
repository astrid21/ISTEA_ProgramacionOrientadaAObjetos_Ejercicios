using System;

namespace Unidad1Ej02_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP_Ver3";

            Cuadrado cuadrado = new Cuadrado();
            cuadrado.Lado = 8;
            cuadrado.XOrigen = 40;
            cuadrado.YOrigen = 5;
            cuadrado.Imprimir();
            Console.WriteLine("Presione cualqueir tecla para continuar");
            Console.ReadKey();
        }
    }
}
