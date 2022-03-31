using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viborita_con_la_people
{
    class Program
    {
        static void Main(string[] args)
        {


            bool escape = false;
            Vibora vibora = new Vibora(0, 0);
            do
            {
                vibora.Imprimir();

                MostrarCoordenadasCabezaVibora(vibora);
                ConsoleKeyInfo teclaLeida = Console.ReadKey(true);

                switch (teclaLeida.Key)
                {
                    case ConsoleKey.UpArrow:
                        vibora.YCabeza--;
                        break;
                    case ConsoleKey.DownArrow:
                        vibora.YCabeza++;
                        break;
                    case ConsoleKey.LeftArrow:
                        vibora.XCabeza--;
                        break;
                    case ConsoleKey.RightArrow:
                        vibora.XCabeza++;
                        break;
                    case ConsoleKey.Escape:
                        escape = true;
                        break;

                }
            } while (!escape);

        }

        private static void MostrarCoordenadasCabezaVibora(Vibora vibora)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 20);
            Console.Write("x:{0} y:{1}", vibora.XCabeza, vibora.YCabeza);


        }
    }
}
