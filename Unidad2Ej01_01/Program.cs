using System;

namespace Unidad2Ej01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador Resultado = new Sumador();
            Console.WriteLine("El resultado de sumar 2 y 3 es: " + Resultado.Sumar(2, 3));
            Console.WriteLine("El restulado de sumar hola y chau es: " + Resultado.Sumar("hola", "chau"));
            Console.ReadKey();
        }
    }
}
