using System;
namespace Unidad3Ej03_02
{
    public class Asterisco
    {
        public Asterisco()
        {
            this.Color = ConsoleColor.White;
        }
        public ConsoleColor Color { set; get; }

        public int X { set; get; }
        public int Y { set; get; }

        public void Imprimir()
        {
            Console.CursorLeft = this.X;
            Console.CursorTop = this.Y;
            Console.ForegroundColor = Color;
            Console.Write("*");
        }

    }
}
