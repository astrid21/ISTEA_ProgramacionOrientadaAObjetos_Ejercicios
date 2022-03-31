using System;
using System.Collections.Generic;

namespace Unidad3Ej04_01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            string palabra;
            Queue<string> ColaDePalabras = new Queue<string>();
            Console.WriteLine("Ingrese la palabra a enconlar");
            Console.WriteLine("- para desencolar");
            Console.WriteLine("l Listar");
            Console.WriteLine("ENTER para terminar");

            do
            {
               palabra = Console.ReadLine();
                switch (palabra)
                {
                    case "":
                        continuar = false;
                        break;
                    case "-":
                        ColaDePalabras.Dequeue();
                        break;
                    case "l":
                        ListarPalabras(ColaDePalabras);
                        break;
                    default:
                        ColaDePalabras.Enqueue(palabra);
                        break;
                }

            } while (continuar);
        }


        private static void ListarPalabras(Queue<string> Cola)
        {
            Console.WriteLine("\t\x5e");
            Console.WriteLine("\t\x5e");
            foreach (string palabra in Cola)
            {
                Console.WriteLine(palabra);
            }
            Console.WriteLine("\t\x5e");
            Console.WriteLine("\t\x5e");
        }

    }
}
