using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Libro : IEntity
    {      
        public int? Id { get; set; }
        public string CodigoIdentificacionUnico { set; get; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int? IdLector { get; set; }
        /// <summary>
        /// Indica si el libro esta prestado.
        /// </summary>
        /// <remarks>
        /// Propiedad calculada en base a un campo de la base de datos, no es persistirle.
        /// </remarks>
        public bool Prestado
        {
            get { return this.IdLector.HasValue; }
        }
    }
}
