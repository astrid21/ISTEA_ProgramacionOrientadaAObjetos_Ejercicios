using System;

namespace Unidad2Ej01_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Teclado teclado = new Teclado();
            int x;
            Console.Write("Ingrese un entero:");
            teclado.Leer(out x);
            Console.WriteLine("El valor ingresado es:" + x);

            float f;
            Console.Write("Ingrese un valor real:");
            teclado.Leer(out f);
            Console.WriteLine("El valor ingresado es:" + f);

            char car;
            Console.Write("Ingrese un valor caracter:");
            teclado.Leer(out car);
            Console.WriteLine("El valor ingresado es:" + car);

            bool l;
            Console.Write("Ingrese un valor logico:");
            teclado.Leer(out l);
            Console.WriteLine("El valor ingresado es:" + l);

            Console.WriteLine();
            Console.Write("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
