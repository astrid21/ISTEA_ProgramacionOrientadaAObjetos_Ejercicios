using System;

namespace Unidad2Ej01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Pantalla pantalla = new Pantalla();
            pantalla.Mostrar("Luis Federico Leloir");
            pantalla.Mostrar("Manuel Sadosky", 30, 10);
            pantalla.Mostrar("Jose Antonio Balseiro", 30, 12, ConsoleColor.Red);
            pantalla.Mostrar("Salvador Mazza", 30, 14, ConsoleColor.Red, ConsoleColor.Blue);
            Console.ReadKey();
        }
    }
}
