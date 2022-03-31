using System;

namespace Unidad4Ej02_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Suma suma = new Suma();
            suma.Valor1 = 10;
            suma.Valor2 = 7;
            suma.Operar();
            Console.WriteLine("La suma de " + suma.Valor1 + " y " +
              suma.Valor2 + " es " + suma.Resultado);

            Resta resta = new Resta();
            resta.Valor1 = 8;
            resta.Valor2 = 4;
            resta.Operar();
            Console.WriteLine("La diferencia de " + resta.Valor1 +
              " y " + resta.Valor2 + " es " + resta.Resultado);

            Console.ReadKey();
        }
    }
}
