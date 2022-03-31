using System;

namespace Unidad3Ej03_02
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
                MostrarCabezaVibora(vibora);
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


            } while (escape == false);

        }

        private static void MostrarCabezaVibora(Vibora vibora)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 20);
            Console.Write("x:{0} y:{1}", vibora.XCabeza, vibora.YCabeza);
        }
    }
}
