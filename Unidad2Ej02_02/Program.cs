using System;

namespace Unidad2Ej02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crea un  objeto punto solo con sus coordenadas.
            Punto punto = new Punto(30, 2);
            punto.Imprimir();

            //Crea un  objeto punto con sus coordenadas y su color.
            Punto puntoRojo = new Punto(30, 3, ConsoleColor.Red);
            puntoRojo.Imprimir();

            //Crea un  objeto punto con sus coordenadas, color principal y color de fondo.
            Punto puntoVerdeYFondoAmarillo = new Punto(30, 4, ConsoleColor.Green, ConsoleColor.Yellow);
            puntoVerdeYFondoAmarillo.Imprimir();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
