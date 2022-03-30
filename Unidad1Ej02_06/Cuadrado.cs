using System;
namespace Unidad1Ej02_06
{
    /// <summary>
    /// Representacion de un cuadrado en objeto
    /// </summary>
    public class Cuadrado
    {
        /// <summary>
        /// Imprime la totalidad del cuadrado
        /// </summary>
        public void Imprimir()
        {
            for (int i = 0; i < Lado; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            for (int i = 0; i < Lado - 2; i++)
            {
                Console.Write("*");
                Console.CursorLeft = Lado - 1;
                Console.Write("*");
                Console.WriteLine();
            }
            for (int i = 0; i < Lado; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();




        }

        /// <summary>
        /// Medida del lado del cuadrado
        /// </summary>
        public int Lado { set; get; }


    }
}
