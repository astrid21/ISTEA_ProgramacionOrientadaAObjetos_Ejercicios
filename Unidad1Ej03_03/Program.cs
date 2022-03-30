using System;
using System.Collections.Generic;

namespace Unidad1Ej03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool seguir = true;
            List<Roca> Rocas = new List<Roca>()
            {
                new Roca(10, 5),
                new Roca(20, 20),
                new Roca(45, 40)
            };

            Nave nave = new Nave(15, 10);

            Espacio espacio = new Espacio();

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        nave.CoordY++;
                        break;
                    case ConsoleKey.UpArrow:
                        nave.CoordY--;
                        break;
                    case ConsoleKey.LeftArrow:
                        nave.CoordX--;
                        break;
                    case ConsoleKey.RightArrow:
                        nave.CoordX++;
                        break;
                    case ConsoleKey.Escape:
                        seguir = false;
                        break;
                }

                if(espacio.HayCoalicion(nave,Rocas) == false)
                {
                    nave.Mover();
                }
                else
                {
                    nave.Explosion(nave);
                    Console.ReadKey();

                    seguir = false;

                }

            } while (seguir);



            
        }
    }
}
