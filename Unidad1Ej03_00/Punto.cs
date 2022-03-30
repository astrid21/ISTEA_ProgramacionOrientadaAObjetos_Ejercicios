using System;
namespace Unidad1Ej03_00
{
    public class Punto
    {
        public int CoorX { set; get; }

        public int CoorY { set; get; }

        public void Imprimir()
        {
            Console.CursorLeft = CoorX;
            Console.CursorTop = CoorY;
            Console.WriteLine(".");
        }

        public void MoverALaDerecha()
        {
            CoorX++;
            Imprimir();
        }

        public void MoverALaIzquierda()
        {
            CoorX--;
            Imprimir();
        }

        public void Borrar()
        {
            Console.CursorLeft = CoorX;
            Console.CursorTop = CoorY;
            Console.WriteLine(" ");
        }
    }
}
