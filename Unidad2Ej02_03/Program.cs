using System;

namespace Unidad2Ej02_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Punto puntoOrigen = new Punto(30, 2);
            puntoOrigen.Imprimir();

            Punto puntoDesplazado = puntoOrigen;
            for (int i = 0; i < 10; i++)
            {
                puntoDesplazado = new Punto(puntoDesplazado);
                puntoDesplazado.Imprimir();
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
