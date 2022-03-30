using System;
namespace Unidad2Ej01_03
{
    public class Pantalla
    {
        public void Mostrar(string Mensaje)
        {
            Console.Write(Mensaje);
        }

        public void Mostrar(string Mensaje, int columna, int fila)
        {
            Console.CursorTop = fila;
            Console.CursorLeft = columna;
            Console.Write(Mensaje);
        }

        public void Mostrar(string Mensaje, int columna, int fila, ConsoleColor colorletra)
        {
            Console.ForegroundColor = colorletra;
            Console.CursorTop = fila;
            Console.CursorLeft = columna;
            Console.Write(Mensaje);
        }

        public void Mostrar(string Mensaje, int columna, int fila, ConsoleColor colorletra, ConsoleColor colorfondo)
        {
            Console.ForegroundColor = colorletra;
            Console.BackgroundColor = colorfondo;
            Console.CursorTop = fila;
            Console.CursorLeft = columna;
            Console.Write(Mensaje);
        }
    }
}
