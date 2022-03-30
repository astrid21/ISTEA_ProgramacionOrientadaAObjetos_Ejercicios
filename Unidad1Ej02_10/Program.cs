using System;

namespace Unidad1Ej02_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LINEAVERTICALOOP_Ver4";

            Cuadrado cuadrado = new Cuadrado();
            cuadrado.Lado = 4;
            cuadrado.XOrigen = 15;
            cuadrado.YOrigen = 10;
            cuadrado.Imprimir();

            bool seguir = true;

            do
            {
                ConsoleKeyInfo teclaLeida = Console.ReadKey(false);
                switch (teclaLeida.Key)
                {
                    case ConsoleKey.DownArrow:
                        cuadrado.YOrigen++;
                        break;
                    case ConsoleKey.UpArrow:
                        cuadrado.YOrigen--;
                        break;
                    case ConsoleKey.RightArrow:
                        cuadrado.XOrigen++;
                        break;
                    case ConsoleKey.LeftArrow:
                        cuadrado.XOrigen--;
                        break;
                    case ConsoleKey.Add:
                        cuadrado.Lado++;
                        break;
                    case ConsoleKey.Subtract:
                        cuadrado.Lado--;
                        break;
                    case ConsoleKey.Escape:
                        seguir = false;
                        break;
                    default:
                        break;
                }

                Console.Clear();

                cuadrado.Imprimir();

            } while (seguir);


            


        }
    }
}
