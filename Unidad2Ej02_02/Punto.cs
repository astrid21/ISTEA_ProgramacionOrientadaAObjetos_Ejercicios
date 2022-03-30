using System;
namespace Unidad2Ej02_02
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

        public Punto(int x, int y, ConsoleColor colorpunto) : this(x, y)
        {
            Console.ForegroundColor = colorpunto;
        }

        public Punto(int x, int y, ConsoleColor colorpunto, ConsoleColor colorfondo) : this(x, y, colorpunto)
        {
            Console.BackgroundColor = colorfondo;
        }

        public void Imprimir()
        {
            Console.SetCursorPosition(this.CoordX, this.CoordY);
            Console.Write(".");
        }
    }
}
