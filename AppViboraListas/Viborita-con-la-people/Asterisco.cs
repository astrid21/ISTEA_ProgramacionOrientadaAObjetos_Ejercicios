using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viborita_con_la_people
{
    class Asterisco
    {
        public Asterisco()
        {
            Color = ConsoleColor.White;
        }

        public ConsoleColor Color { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Imprimir()
        {
            Console.ForegroundColor = this.Color;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("*");
        }



    }
}
