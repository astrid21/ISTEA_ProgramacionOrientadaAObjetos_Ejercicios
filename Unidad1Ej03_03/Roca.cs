using System;
namespace Unidad1Ej03_03
{
    public class Roca
    {
        public int CoordX { set; get; }
        public int CoordY { set; get; }

        public Roca(int x, int y)
        {
            this.CoordX = x;
            this.CoordY = y;

            Console.CursorLeft = CoordX;
            Console.CursorTop = CoordY;
            Console.Write("#");
        }


    }
}
