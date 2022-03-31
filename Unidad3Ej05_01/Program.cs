using System;
using System.Collections.Generic;

namespace Unidad3Ej05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> PilaPalabras = new Stack<string>();
            string palabra;
            bool continuar = true;
            Console.WriteLine("Ingrese palabras y Enter o Enter solo para finalizar");

            do
            {
                palabra = Console.ReadLine();
                if(palabra== "")
                {
                    MostrarPilaAlReves(PilaPalabras);
                    continuar = false;
                    Console.WriteLine("Presione cualquier tecla para salir");
                    Console.ReadKey();
                }
                else
                {
                    PilaPalabras.Push(palabra);
                }

            } while (continuar);
        }

        private static void MostrarPilaAlReves(Stack<string> Pila)
        {
            int largo = Pila.Count;
            Console.WriteLine("La frase en orden inverso es:");
            for (int i = 0; i < largo; i++)
            {
                Console.Write(Pila.Pop() + " ");
            }
            Console.WriteLine();
            
        }
    }
}
