using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplicacionVibora
{
    //Prototipo o firma del manejador del evento.
    public delegate void MoverEventHandler(Vibora vivora);

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
            Asteriscos = new List<Asterisco>();
            Asterisco asterisco = new Asterisco();
            asterisco.X = this.XCabeza;
            asterisco.Y = this.YCabeza;
            Asteriscos.Add(asterisco);
            for (int i = 0; i < LARGO-1; i++)
            {
                asterisco = new Asterisco();
                asterisco.X = this.XCabeza;
                asterisco.Y = this.YCabeza + i;
                Asteriscos.Add(asterisco);
            }
        }

        //Largo de la vibora medido en cantidad de asteriscos.
        public const int LARGO = 20;

        /// <summary>
        /// Valor de la coordenada X en la que está posicionada la cabeza.
        /// </summary>
        private int _XCabeza;
        public int XCabeza 
        { 
            set 
            {
                _XCabeza = value;
                this.Mover();                
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
                _YCabeza = value;
                this.Mover();
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
            Console.Clear();
            
            //Muestra el cuerpo
            foreach (Asterisco asterisco in Asteriscos)
            {
                asterisco.Imprimir();    
            }

            //Muestra la cabeza de la víbora.
            Asterisco cabeza = Asteriscos[0];
            cabeza.Color = ConsoleColor.Red;
            cabeza.Imprimir();
        }

        /// <summary>
        /// Mueve cada uno de los asteriscos que la componen al siguiente inmediato, 
        /// causando así el desplazamiento completo de la víbora.
        /// </summary>
        public void Mover()
        {
            if (OnBeforeMover != null) OnBeforeMover(this); //Si existe algún suscriptor dispara el evento.

            this.MoverAccion(); //Realiza la acción concreta de mover a la víbora.

            if (OnAfterMover != null) OnAfterMover(this);   //Si existe algún suscriptor dispara el evento.
        }

        /// <summary>
        /// Se dispara entes que la víbora se mueva.
        /// </summary>
        public event MoverEventHandler OnBeforeMover;

        /// <summary>
        /// Se dispara después que la víbora se mueva.
        /// </summary>
        public event MoverEventHandler OnAfterMover;

        /// <summary>
        /// Realiza la acción de mover o trasladar la víbora.
        /// </summary>
        private void MoverAccion()
        {
            for (int i = Asteriscos.Count - 1; i > 0; i--)
            {
                Asteriscos[i].X = Asteriscos[i - 1].X;
                Asteriscos[i].Y = Asteriscos[i - 1].Y;
            }
            Asteriscos[0].X = this.XCabeza;
            Asteriscos[0].Y = this.YCabeza;
        }

        /// <summary>
        /// Lista de asteriscos que componen la víbora.
        /// </summary>
        public List<Asterisco> Asteriscos;
    }
}