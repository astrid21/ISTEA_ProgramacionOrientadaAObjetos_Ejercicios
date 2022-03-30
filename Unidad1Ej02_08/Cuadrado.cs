using System;
namespace Unidad1Ej02_08
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
            this.ImprimirBase();
            this.ImprimirLateral();
            if (_Lado != 1)
            {
                this.ImprimirBase();
            }
        }


        private int _Lado;

        /// <summary>
        /// Medida del lado del cuadrado
        /// </summary>
        public int Lado
        {
            set
            {
                if (value < 1)
                {
                    throw new Exception("ERROR, El valor del lado del cuadrado no puede ser menor que 1");
                }

                _Lado = value;
            }

            get
            {
                return _Lado;
            }
        }

        /// <summary>
        /// Imprime las caras de arriba o abajo del cuadrado
        /// </summary>
        private void ImprimirBase()
        {
            for (int i = 0; i < _Lado; i++)
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
            for (int i = 0; i < (_Lado - 2); i++)
            {
                Console.Write("*");
                Console.CursorLeft = (_Lado - 1) * 2;
                Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
