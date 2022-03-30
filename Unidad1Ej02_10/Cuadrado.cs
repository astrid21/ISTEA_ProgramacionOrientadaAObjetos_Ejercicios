using System;
namespace Unidad1Ej02_10
{
    /// <summary>
    /// Representacion de un cuadrado en objeto
    /// </summary>
    public class Cuadrado
    {

        /// <summary>
        /// Medida del lado del cuadrado
        /// </summary>
        public int Lado { set; get; }

        /// <summary>
        /// Coordenada X de la esquina superior izquierda del cuadrado
        /// </summary>
        public int XOrigen { set; get; }

        /// <summary>
        /// Coordenada Y de la esquina superior izquierda del cuadrado
        /// </summary>
        public int YOrigen { set; get; }


        /// <summary>
        /// Imprime la totalidad del cuadrado
        /// </summary>
        public void Imprimir()
        {
            this.ImprimirTecho();
            this.ImprimirLateral();
            if (Lado != 1)
            {
                this.ImprimirBase();
            }
        }


        /// <summary>
        /// Imprime las caras de arriba o abajo del cuadrado
        /// </summary>
        private void ImprimirTecho()
        {
            Console.CursorLeft = XOrigen;
            Console.CursorTop = YOrigen;
            for (int i = 0; i < Lado; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Imprime las caras laterales del cuadrado
        /// </summary>
        private void ImprimirLateral()
        {

            for (int i = 0; i < (Lado - 2); i++)
            {
                Console.CursorTop = YOrigen + i + 1;
                Console.CursorLeft = XOrigen;
                Console.Write("*");
                Console.CursorTop = YOrigen + i + 1;
                Console.CursorLeft = XOrigen + (Lado - 1) * 2;
                Console.Write("*");
                Console.WriteLine();
            }
        }

        private void ImprimirBase()
        {
            Console.CursorLeft = XOrigen;
            Console.CursorTop = YOrigen + Lado - 1;
            for (int i = 0; i < Lado; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
