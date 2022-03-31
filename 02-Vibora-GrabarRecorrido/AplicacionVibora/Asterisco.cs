using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplicacionVibora
{
    /// <summary>
    /// Representación en objetos de un asterisco.
    /// </summary>
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
        /// Valor de la coordenada Y en la que está posicionado.
        /// </summary>
        public int Y { set; get; }
    
        /// <summary>
        /// Muestra por pantalla un asterisco en la posición y color establecidos.
        /// </summary>
        public void Imprimir()
        {            
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write("*");
        }
    }
}
