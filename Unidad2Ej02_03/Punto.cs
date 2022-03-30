using System;
namespace Unidad2Ej02_03
{
    public class Punto
    {
        public int CoordX { set; get; }
        public int CoordY { set; get; }

        public Punto(int x, int y)
        {
            this.CoordX = x;
            this.CoordY = y;
        }

        public Punto(Punto punto):this(punto.CoordX+1, punto.CoordY+1)
        {
            
        }

        public void Imprimir()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.Write(".");
        }
    }
}
