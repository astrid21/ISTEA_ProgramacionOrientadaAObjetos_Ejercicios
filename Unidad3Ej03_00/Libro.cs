using System;
namespace Unidad3Ej03_00
{
    public class Libro
    {
        public Libro(string texto)
        {
            this.Texto = texto;
        }

        /// <summary>
        /// Texto que contiene el libro.
        /// </summary>
        public string Texto { set; get; }
    }
}
