using System;
namespace Unidad1Ej02_05
{
    public class LineaV
    {

        public void Imprimir()
        {
            for (int i = 0; i < Largo; i++)
            {
                Console.WriteLine("|");
            }
        }


        public int Largo { set; get; }

    }
}
