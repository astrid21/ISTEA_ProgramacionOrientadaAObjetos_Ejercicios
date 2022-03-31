using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExceptionApplication
{
    /// <summary>
    /// Representación en objetos de un científico.
    /// </summary>
    public class CientificoArgentino
    {
        public CientificoArgentino(string apellido, string nombre)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
        }

        public string Apellido { set; get; }
        public string Nombre { set; get; }
    }
}
