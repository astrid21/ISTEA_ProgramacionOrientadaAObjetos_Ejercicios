using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Impresora impresora = Impresora.Instance;   //Se crea la única instancia de la impresora.
            impresora.Documento = "Cuanta verdad podemos soportar";
            impresora.Imprimir();

            Impresora impresora_A = Impresora.Instance;

            bool mismaImpresora = object.ReferenceEquals(impresora, impresora_A);
            if (mismaImpresora)
                Console.WriteLine("impresora e impresora_A son la misma y única impresora");

            Console.ReadKey();
        }
    }
}

