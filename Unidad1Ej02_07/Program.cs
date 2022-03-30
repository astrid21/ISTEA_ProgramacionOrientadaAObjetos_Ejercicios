using System;

namespace Unidad1Ej02_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP_Ver1";
            // Pido la medida del lado por consola
            Console.Write("Ingrese el largo del lado del cuadrado: ");
            int medidaLado = int.Parse(Console.ReadLine());

            Cuadrado cuadrado = new Cuadrado();
            cuadrado.Lado = medidaLado;
            cuadrado.Imprimir();
            Console.WriteLine("Presione cualqueir tecla para continuar");
            Console.ReadKey();
        }
    }
}
