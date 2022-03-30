using System;

namespace Unidad1Ej02_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TableroTaTeTi";

            // Pido la medida del lado por consola
            Console.Write("Ingrese el largo del lado de una de las celdas: ");
            int medidaLado = int.Parse(Console.ReadLine());

            TableroTaTeTi Tablero = new TableroTaTeTi();
            Tablero.LadoCuadrado = medidaLado;
            Tablero.XOrigen = 10;
            Tablero.YOrigen = 5;
            Tablero.Imprimir();
            Console.WriteLine("Presione cualqueir tecla para continuar");
            Console.ReadKey();
        }
    }
}
