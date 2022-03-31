using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExceptionApplication
{
    /// <summary>
    /// Administra la colección de científicos.
    /// </summary>
    public class Persistidor
    {
        public Persistidor()
        {
            this.Cientificos = new List<CientificoArgentino>();
            this.Cientificos.Add(new CientificoArgentino("Sadosky", "Manuel"));
            this.Cientificos.Add(new CientificoArgentino("Leloir", "Luis Federico"));            
            this.Cientificos.Add(new CientificoArgentino("Houssay", "Bernardo Alberto"));
            this.Cientificos.Add(new CientificoArgentino("Favaloro", "René"));        
        }

        public List<CientificoArgentino> Cientificos { get; private set; }

        public void Adicionar(CientificoArgentino nuevoCientifico)
        {
            #region Evaluación de la precondición de Apellido de ingreso obligatorio
            if (string.IsNullOrEmpty( nuevoCientifico.Apellido))
                throw new ApellidoCientificoRequeridoException();
            #endregion

            #region Evaluación de la precondición de existencia del científico
            foreach (CientificoArgentino cientifico in this.Cientificos)
            {
                //Realiza la comparación sin distinguir entre mayúsculas y minúsculas.
                bool yaExiste = string.Equals(cientifico.Apellido, nuevoCientifico.Apellido, StringComparison.CurrentCultureIgnoreCase);
                if (yaExiste)
                {
                    throw new CientificoYaExisteException();
                }
            };
            #endregion

            this.Cientificos.Add(nuevoCientifico);
        }

        public class CientificoYaExisteException : Exception { }
        public class ApellidoCientificoRequeridoException : Exception { }
    }
}
