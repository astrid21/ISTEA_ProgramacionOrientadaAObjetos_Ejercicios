using System;
namespace Unidad2Ej01_02
{
    public class Sumador
    {
        public int Sumar(int x, int y)
        {
            return x + y;
        }

        public string Sumar(string x, string y)
        {
            return x + y;
        }

        public Cuaderno Sumar(Cuaderno x, Cuaderno y)
        {
            Cuaderno resul = new Cuaderno(0);
            resul.CantDeHojas = x.CantDeHojas + y.CantDeHojas;
            return resul;
        }
    }
}
