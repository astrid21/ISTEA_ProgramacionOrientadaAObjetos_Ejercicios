using System;
namespace Unidad4Ej01_04
{
    public class Asterisco
    {
        public Asterisco()
        {
            this.Color = ConsoleColor.White;    //Inicializa el color por defecto a blanco
        }

        /// <summary>
        /// Color con el que se muestra el asterisco.
        /// </summary>
        public ConsoleColor Color { set; get; }

        /// <summary>
        /// Valor de la coordenada X en la que está posicionado.
        /// </summary>
        public int X { set; get; }

        /// <summary>
        /// Valor de la coordenada X en la cual se realizó 
        /// la última impresión en pantalla.
        /// </summary>        
        public int? XImpresa { set; get; }

        /// <summary>
        /// Valor de la coordenada Y en la que está posicionado.
        /// </summary>
        public int Y { set; get; }

        /// <summary>
        /// Valor de la coordenada Y en la cual se realizó 
        /// la última impresión en pantalla.
        /// </summary>        
        public int? YImpresa { set; get; }

        /// <summary>
        /// Muestra por pantalla un asterisco en la posición y color establecidos.
        /// </summary>
        public void Imprimir()
        {
            this.XImpresa = this.X;
            this.YImpresa = this.Y;

            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("*");
        }

        /// <summary>
        /// Borra de la pantalla el último asterisco impreso.
        /// </summary>
        public void Borrar()
        {
            if (this.XImpresa.HasValue && this.YImpresa.HasValue)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(this.XImpresa.Value, this.YImpresa.Value);
                Console.Write(" ");
            }
        }
    }
}
