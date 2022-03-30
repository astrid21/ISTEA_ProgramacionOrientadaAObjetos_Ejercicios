using System;
namespace Unidad1Ej04_01
{
    /// <summary>
    /// Representación de un avión en objetos.
    /// </summary>
    public class Avion
    {
        /// <summary>
        /// Aumenta la velocidad del avión.
        /// </summary>
        public void Acelerar()
        {
            _Motor.RPM++;
        }

        /// <summary>
        /// Disminuye la velocidad del avión.
        /// </summary>
        public void Disminuir()
        {
            _Motor.RPM--;
        }

        private Motor _Motor = new Motor();

        /// <summary>
        /// Motor del avion.
        /// </summary>
        private class Motor
        {
            /// <summary>
            /// Revoluciones Por Minuto (RPM)
            /// </summary>
            public int RPM { set; get; }
        }
    }
}
