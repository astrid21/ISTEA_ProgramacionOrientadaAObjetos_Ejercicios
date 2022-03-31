using System;

namespace Unidad4Ej01_04
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
                MostrarCoordenadasCabezaVivora(vibora);
                ConsoleKeyInfo teclaLeida = Console.ReadKey(true);  //true para que no se muestre la tecla presionada en la pantalla.
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
                    case ConsoleKey.Enter:
                        vibora = CambiarDeVibora(vibora);
                        break;
                    case ConsoleKey.Escape:
                        escape = true;
                        break;
                }
            }
            while (!escape);
        }

        /// <summary>
        /// Muestra las coordenadas X,Y de la cabeza de la víbora.
        /// </summary>
        /// <remarks>
        /// La cabeza de la víbora es de color rojo para distinguirlo del resto del cuerpo.
        /// </remarks>
        private static void MostrarCoordenadasCabezaVivora(Vibora vibora)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(55, 20);
            Console.Write("x:{0} y:{1} {2}", vibora.XCabeza, vibora.YCabeza, vibora.GetType().Name);
        }

        private static Vibora CambiarDeVibora(Vibora vibora)
        {
            vibora.Borrar();
            switch (vibora.GetType().Name)
            {
                case "Vibora":
                    vibora = new ViboraElastica(vibora.XCabeza, vibora.YCabeza);
                    break;
                case "ViboraElastica":
                    vibora = new ViboraDeColores(vibora.XCabeza, vibora.YCabeza);
                    break;
                case "ViboraDeColores":
                    vibora = new ViboraReductora(vibora.XCabeza, vibora.YCabeza);
                    break;
                case "ViboraReductora":
                    vibora = new Vibora(vibora.XCabeza, vibora.YCabeza);
                    break;
            }
            return vibora;
        }
    }
    
}
