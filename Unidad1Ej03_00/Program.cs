using System;

namespace Unidad1Ej03_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PuntoAnimado";
            Console.WriteLine("Presione la tecla 'Esc' para salir.");
            Console.WriteLine("Presione las flechas para mover al punto");

            Punto punto = new Punto();
            punto.CoorX = 15;
            punto.CoorY = 10;
            punto.Imprimir();



            bool seguir = true;

            do
            {

                ConsoleKeyInfo teclaLeida = Console.ReadKey(false);
                switch (teclaLeida.Key)
                {
                    case ConsoleKey.RightArrow:
                        punto.Borrar();

                        punto.MoverALaDerecha();
                        break;
                    case ConsoleKey.LeftArrow:
                        punto.Borrar();

                        punto.MoverALaIzquierda();
                        break;
                    case ConsoleKey.Escape:
                        seguir = false;
                        break;
                    default:
                        break;
                }



            } while (seguir);
        }
    }
}
