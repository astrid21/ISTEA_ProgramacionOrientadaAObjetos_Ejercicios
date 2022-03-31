using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesApplication
{
    public static class Divisor
    {
        /*
         http://ortizol.blogspot.com.ar/2014/07/excepciones-en-csharp-parte-5-ejemplos-de-excepciones-comunes.html
         */

        /// <summary>
        /// Divide un número par en dos partes iguales.
        /// </summary>
        /// <param name="numeroPar">
        /// Numero par a dividir.
        /// </param>
        /// <returns></returns>
        public static int DividirPorDos(int numeroPar)
        {
            #region Precondición, evalúa que el parametro sea un número par.
            if ((numeroPar % 2) != 0)
            {
                throw new ArgumentException("El número debe cumplir como precondición que sea par.", "numeroPar");
            }
            #endregion

            return numeroPar / 2;
        }
    }
}
