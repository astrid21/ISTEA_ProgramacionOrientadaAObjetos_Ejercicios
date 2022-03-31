using System;
using System.Collections.Generic;

namespace Unidad4Ej01_04
{
        /// <summary>
        /// Representación en objetos de una víbora formada por asteriscos.
        /// </summary>
        /// <remarks>
        /// EL cuerpo de la víbora está formada por asteriscos de color blanco, 
        /// solo su cabeza será un asterisco rojo, además de los asteriscos nos 
        /// hace falta mucha de imaginación.
        /// </remarks>
        public class Vibora
        {
            public Vibora(int xCabeza, int yCabeza)
            {
                this._XCabeza = xCabeza;
                this._YCabeza = yCabeza;
                _Asteriscos = new List<Asterisco>();
                Asterisco asterisco = new Asterisco();
                asterisco.X = this.XCabeza;
                asterisco.Y = this.YCabeza;
                asterisco.Color = ConsoleColor.Red;
                _Asteriscos.Add(asterisco);
                for (int i = 0; i < LARGO - 1; i++)
                {
                    asterisco = new Asterisco();
                    asterisco.X = this.XCabeza;
                    asterisco.Y = this.YCabeza + i + 1;
                    _Asteriscos.Add(asterisco);
                }
            }

            //Largo de la vibora medido en cantidad de asteriscos.
            public const int LARGO = 15;

            //Valor máximo de las ordenadas
            public const int Y_MAX = 20;

            //Valor máximo de las abscisas
            public const int X_MAX = 79;

            /// <summary>
            /// Valor de la coordenada X en la que está posicionada la cabeza.
            /// </summary>
            private int _XCabeza;
            public int XCabeza
            {
                set
                {
                    if (value >= 0 && value <= X_MAX)
                    {
                        _XCabeza = value;
                        this.Mover();
                    }
                }
                get
                {
                    return _XCabeza;
                }
            }

            /// <summary>
            /// Valor de la coordenada Y en la que está posicionada la cabeza.
            /// </summary>
            private int _YCabeza;
            public int YCabeza
            {
                set
                {
                    if (value >= 0 && value <= Y_MAX)
                    {
                        _YCabeza = value;
                        this.Mover();
                    }
                }
                get
                {
                    return _YCabeza;
                }
            }

            /// <summary>
            /// Muestra la víbora por pantalla.
            /// </summary>
            public void Imprimir()
            {
                this.Borrar();

                //Muestra el cuerpo
                foreach (Asterisco asterisco in _Asteriscos)
                {
                    asterisco.Imprimir();
                }

                //Muestra la cabeza de la víbora.
                Asterisco cabeza = _Asteriscos[0];
                cabeza.Color = ConsoleColor.Red;
                cabeza.Imprimir();
            }

            /// <summary>
            /// Borra de la pantalla cada uno de los asteriscos 
            /// que componen la víbora.
            /// </summary>
            public void Borrar()
            {
                foreach (Asterisco asterisco in _Asteriscos)
                {
                    asterisco.Borrar();
                }
            }

            /// <summary>
            /// Mueva cada uno de los asteriscos que la componen al siguiente inmediato, 
            /// causando así el desplazamiento completo de la víbora.
            /// </summary>
            public virtual void Mover()
            {
                for (int i = _Asteriscos.Count - 1; i > 0; i--)
                {
                    _Asteriscos[i].X = _Asteriscos[i - 1].X;
                    _Asteriscos[i].Y = _Asteriscos[i - 1].Y;
                }
                _Asteriscos[0].X = this.XCabeza;
                _Asteriscos[0].Y = this.YCabeza;
            }

            /// <summary>
            /// Lista de asteriscos que componen la víbora.
            /// </summary>
            protected List<Asterisco> _Asteriscos;

            
        }
    
}
