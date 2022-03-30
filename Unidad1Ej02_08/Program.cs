using System;

namespace Unidad1Ej02_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP_Ver2";

            for (int i = 0; i < 6; i++)
            {
                Cuadrado cuadrado = new Cuadrado();
                cuadrado.Lado = i+1;
                cuadrado.Imprimir();
            }

            Console.WriteLine("Presione cualqueir tecla para continuar");
            Console.ReadKey();
        }
    }
}
