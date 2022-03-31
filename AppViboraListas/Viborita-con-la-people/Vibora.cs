using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viborita_con_la_people
{
    public class Vibora
    {
        public const int Largo = 15;

        private int _yCabeza;
        private int _xCabeza;
        private List<Asterisco> _asteriscos;


        public Vibora(int xCabeza, int yCabeza)
        {
            this._xCabeza = xCabeza;
            this._yCabeza = xCabeza;

            _asteriscos = new List<Asterisco>();

            for (int i = 0; i < Largo; i++)
            {
                _asteriscos.Add(new Asterisco());
            }

            _asteriscos[0].Color = ConsoleColor.Red;
            _asteriscos[0].X = xCabeza;
            _asteriscos[0].Y = yCabeza;

        }

        public int YCabeza { get => _yCabeza; set => _yCabeza = value; }
        public int XCabeza { get => _xCabeza; set => _xCabeza = value; }

        public void Imprimir()
        {

            Console.Clear();
            Mover();
            foreach (Asterisco item in _asteriscos)
            {
                item.Imprimir();
            }

        }

        public void Mover()
        {
            for (int i = _asteriscos.Count - 1; i > 0; i--)
            {
                _asteriscos[i].X = _asteriscos[i - 1].X;
                _asteriscos[i].Y = _asteriscos[i - 1].Y;
            }
            _asteriscos[0].X = this.XCabeza;
            _asteriscos[0].Y = this.YCabeza;
        }


    }
}
