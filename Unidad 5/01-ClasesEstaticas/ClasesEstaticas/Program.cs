using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesEstaticas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(Antes de sumar) UltimaOperacion = '{0}'", Matematica.UltimaOperacion);
            Console.WriteLine("Resultado de la suma 10+23={0}", Matematica.Sumar(10,23));
            Console.WriteLine("(Despues de sumar) UltimaOperacion = '{0}'", Matematica.UltimaOperacion);
            Console.WriteLine("Resultado de la multiplicacion 10*23={0}", Matematica.Multiplicar(10, 23));
            Console.WriteLine("(Despues de multiplicar) UltimaOperacion = '{0}'", Matematica.UltimaOperacion);

            Console.ReadKey();
        }
    }
}
