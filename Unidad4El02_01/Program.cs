using System;

namespace Unidad4El02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo circulo = new Circulo(10);          //el aread es: 314

            Cuadrado cuadrado = new Cuadrado(10);       //el area es: 100

            Triangulo triangulo = new Triangulo(10, 2); //el area es: 10

            Console.WriteLine("Area area del {0} es {1}", circulo.GetType().Name, circulo.Area());
            Console.WriteLine("Area area del {0} es {1}", cuadrado.GetType().Name, cuadrado.Area());
            Console.WriteLine("Area area del {0} es {1}", triangulo.GetType().Name, triangulo.Area());

            Console.ReadKey();
        }
    }
}
