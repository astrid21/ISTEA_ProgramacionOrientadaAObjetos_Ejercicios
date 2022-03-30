using System;

namespace Unidad2Ej01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador Resultado = new Sumador();
            Cuaderno A = new Cuaderno(33);
            Cuaderno B = new Cuaderno(44);

            Console.WriteLine("El resultado de sumar 2 y 3 es: " + Resultado.Sumar(2, 3));
            Console.WriteLine("El restulado de sumar hola y chau es: " + Resultado.Sumar("hola", "chau"));
            Console.WriteLine("El resultado de la cantidad de hojas de sumar cuadernos A y B es: " + Resultado.Sumar(A, B).CantDeHojas);
            Console.ReadKey();
        }
    }
}
