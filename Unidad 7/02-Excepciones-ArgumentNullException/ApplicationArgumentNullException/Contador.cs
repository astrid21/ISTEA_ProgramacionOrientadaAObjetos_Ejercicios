using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationArgumentNullException
{
    public class Contador
    {
        /// <summary>
        /// Cuenta la cantidad de espacios que forman parte de 
        /// una cadena evaluando una precondición.
        /// </summary>
        public int ContarEspacios(Documento documento)
        {
            #region Evaluación de la precondición
            if (documento == null)
            {
                throw new ArgumentNullException("documento", "El parámetro no es válido ya que es nulo.");
            }
            else
            {
                if (documento.Texto == null)
                    throw new InvalidOperationException("El texto del documento no existe");
            }
            #endregion
      
            int cantEspacios = CountSpaceChars(documento.Texto);
            
            return cantEspacios;
        }

        /// <summary>
        /// Cuenta la cantidad de espacios que forman parte de 
        /// una cadena sin evaluar ninguna precondición.
        /// </summary>
        /// <param name="value">
        /// Cadena a la que se le desea contabilizar sus espacios.
        /// </param>
        /// <returns>
        /// Numero de espacios.
        /// </returns>
        private int CountSpaceChars(string value)
        {
            int result = 0;
            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
