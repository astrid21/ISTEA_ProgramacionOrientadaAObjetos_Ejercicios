using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesEstaticas
{
    static class Matematica
    {
        static Matematica() 
        {
            UltimaOperacion = "No se ha ejecutado ninguna operación.";
        }

        public static string UltimaOperacion { get; set; }

        public static int Sumar(int a, int b)
        {
            UltimaOperacion = "Sumar";
            return a + b;
        }

        public static int Multiplicar(int a, int b)
        {
            UltimaOperacion = "Multiplicar";
            return a * b;
        }
    }
}
