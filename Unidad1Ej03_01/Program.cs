using System;

namespace Unidad1Ej03_01
{
    class Program
    {

        // NO HABIA ENUNCIADO, SOLO CODIGO RESUELTO. ASI QUE LO COPIE PARA VER QUE HACE!
        // EL CODIGO ES SOBRE EVENTOS QUE HASTA HOY 4 DE ABRIL NO VIMOS!!


        static void Main(string[] args)
        {
            Sumador sumador = new Sumador();
            sumador.OnSumaNegativa += sumador_OnSumaNegativa;
            sumador.SumandoA = -11;
            sumador.SumandoB = 10;
            sumador.Sumar();

        }

        static void sumador_OnSumaNegativa(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public class Sumador
        {
            /* Propiedades */
            public int SumandoA { set; get; }
            public int SumandoB { set; get; }

            /* Metodo */
            public int Sumar()
            {
                int suma = this.SumandoA + this.SumandoB;

                if (suma < 0)
                    this.DispararEventoOnSumaNegativa();

                return suma;
            }

            /* Evento */
            public event EventHandler OnSumaNegativa;

            private void DispararEventoOnSumaNegativa()
            {
                if (OnSumaNegativa != null)
                    OnSumaNegativa(this, null);
            }
        }
    }
}
