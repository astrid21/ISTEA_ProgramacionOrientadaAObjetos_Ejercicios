using System;
using System.Collections.Generic;


namespace Unidad3Ej05_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            string palabra;
            Stack<string> PilaPalabras = new Stack<string>();

            Console.WriteLine("Ingrese la palabra a apilar");
            Console.WriteLine("- para des apilar");
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
                        PilaPalabras.Pop();
                        break;
                    case "l":
                        ListarPalabras(PilaPalabras);
                        break;
                    default:
                        PilaPalabras.Push(palabra);
                        break;
                }

            } while (continuar);
        }

        private static void ListarPalabras(Stack<string> Pila)
        {
            string Flecha_arriba = "\x2191";
            string Flecha_abajo = "\x2193";
            Console.WriteLine("\t" + Flecha_arriba + Flecha_abajo);
            Console.WriteLine("\t" + Flecha_arriba + Flecha_abajo);
            foreach (string palabra in Pila)
            {
                Console.WriteLine(palabra);
            }
            Console.WriteLine("\t" + Flecha_arriba + Flecha_abajo);
            Console.WriteLine("\t" + Flecha_arriba + Flecha_abajo);

        }
    }
}
