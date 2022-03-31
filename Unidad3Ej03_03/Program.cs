using System;
using System.Collections.Generic;

namespace Unidad3Ej03_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ListaNumeros = new List<int> { 1, 4, 7, 2, 23, 5, 12 };
            MostrarNumerosPorConsola(ListaNumeros);

            List<int> ListaOrdenada = OrdenarNumerosPorBurbujeo(ListaNumeros);

            MostrarNumerosPorConsola(ListaNumeros);
            MostrarNumerosPorConsola(ListaOrdenada);



            Console.ReadKey();
        }


        private static void MostrarNumerosPorConsola(List<int> listaParaMostrar)
        {
            foreach (int numero in listaParaMostrar)
            {
                Console.Write(numero + " ");
            }
            Console.WriteLine();
        }

        private static List<int> OrdenarNumerosPorBurbujeo(List<int> listaParaOrdenar)
        {
            List<int> Copia = new List<int>();
            int aux;
            foreach (int numero in listaParaOrdenar)
            {
                Copia.Add(numero);
            }

            for (int i = 0; i < Copia.Count -1; i++)
            {
                for (int j = i+1; j < Copia.Count; j++)
                {
                    if(Copia[i] > Copia[j])
                    {
                        aux = Copia[i];
                        Copia[i] = Copia[j];
                        Copia[j] = aux;
                    }
                }

            }

            return Copia;
        }
    }
}
