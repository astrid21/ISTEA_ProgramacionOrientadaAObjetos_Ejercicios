using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AplicacionVibora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool escape = false;
            Persistidor.EliminarCaminoGrabado();
            Vibora vivora = new Vibora(0, 0);
            vivora.OnAfterMover += vivora_OnAfterMover; //Suscripción al evento OnAfterMover
            do
            {
                vivora.Imprimir();
                MostrarCoordenadasCabezaVivora(vivora);
                ConsoleKeyInfo teclaLeida = Console.ReadKey(true);  //true para que no se muestre la tecla presionada en la pantalla.
                switch (teclaLeida.Key)
                {
                    case ConsoleKey.UpArrow:
                        vivora.YCabeza--;
                        break;
                    case ConsoleKey.DownArrow:
                        vivora.YCabeza++;
                        break;
                    case ConsoleKey.LeftArrow:
                        vivora.XCabeza--;
                        break;
                    case ConsoleKey.RightArrow:
                        vivora.XCabeza++;
                        break;
                    case ConsoleKey.Enter:
                        MostrarCaminoRecorrido();
                        break;
                    case ConsoleKey.Escape:
                        escape = true;
                        break;
                }
            }
            while (!escape);
        }

        /// <summary>
        /// Muestra el camino recorrido por la víbora leyéndolo desde un 
        /// archivo de texto utilizado como base de datos.
        /// </summary>
        private static void MostrarCaminoRecorrido()
        {
            Console.Clear();
            List<Asterisco> caminoDeAsteriscos = Persistidor.LeerCaminoGrabado();
            foreach (Asterisco asterisco in caminoDeAsteriscos)
            {
                asterisco.Imprimir();            
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Rutina de atención al evento OnAfterMover.
        /// </summary>
        /// <param name="vivora"></param>
        static void vivora_OnAfterMover(Vibora vibora)
        {
            Persistidor.GrabarCoordenadas(vibora);
        }

        /// <summary>
        /// Muestra las coordenadas X,Y de la cabeza de la víbora.
        /// </summary>
        /// <remarks>
        /// La cabeza de la víbora es de color rojo para distinguirlo del resto del cuerpo.
        /// </remarks>
        private static void MostrarCoordenadasCabezaVivora(Vibora vivora)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(60, 20);
            Console.Write("x:{0} y:{1}", vivora.XCabeza, vivora.YCabeza);
            Console.SetCursorPosition(60, 21);
            Console.Write("Enter = recorrido.");
        }
    }
}
