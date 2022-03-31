using System;
using System.Collections.Generic;

namespace ejercicioBurbujeo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Coche> coches = new List<Coche>();
            coches.Add(new Coche { Matricula = "YVZ 134" });
            coches.Add(new Coche { Matricula = "ZVZ 999" });
            coches.Add(new Coche { Matricula = "AVZ 998" });
            coches.Add(new Coche { Matricula = "BVZ 459" });
            coches.Add(new Coche { Matricula = "BVZ 459" });

            foreach (Coche aux in coches)
            {
                Console.WriteLine(aux.Matricula);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            bool hayCambio = false;
            do
            {
                hayCambio = false;
                for (int i = 0; i < coches.Count - 1; i++)
                {
                    if (String.Compare(coches[i].Matricula, coches[i + 1].Matricula) > 0)
                    {
                        string aux = coches[i].Matricula;
                        coches[i].Matricula = coches[i + 1].Matricula;
                        coches[i + 1].Matricula = aux;

                        hayCambio = true;
                    }
                }

            } while (hayCambio);
            Console.WriteLine("");

            foreach (Coche aux in coches)
            {
                Console.WriteLine(aux.Matricula);
            }
            Console.ReadKey();
        }
    }
}
