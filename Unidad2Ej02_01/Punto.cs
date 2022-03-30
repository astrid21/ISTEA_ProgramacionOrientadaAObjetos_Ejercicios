using System;
namespace Unidad2Ej02_01
{
    public class Punto
    {
        public Punto(int x, int y)
        {
            this.CoordX = x;
            this.CoordY = y;
        }

        public int CoordX { set; get; }
        public int CoordY { set; get; }

        public void Imprimir()
        {
            Console.CursorTop = CoordX;
            Console.CursorLeft = CoordY;
            Console.Write(".");
        }


    }
}
