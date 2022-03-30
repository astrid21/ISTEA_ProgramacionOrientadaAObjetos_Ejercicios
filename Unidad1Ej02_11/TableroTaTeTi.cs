using System;
namespace Unidad1Ej02_11
{
    public class TableroTaTeTi
    {
        /// <summary>
        /// Medida del lado del cuadrado del tateti
        /// </summary>
        public int LadoCuadrado { set; get; }

        /// <summary>
        /// Coordenada X de la esquina superior izquierda del tateti
        /// </summary>
        public int XOrigen { set; get; }

        /// <summary>
        /// Coordenada Y de la esquina superior izquierda del tateti
        /// </summary>
        public int YOrigen { set; get; }

        public void Imprimir()
        {

            Cuadrado cuadrado = new Cuadrado();
            cuadrado.Lado = LadoCuadrado;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cuadrado.XOrigen = this.XOrigen + (LadoCuadrado  * 2 - 2)  * i;
                    cuadrado.YOrigen = this.YOrigen + (LadoCuadrado  -1)* j;
                    cuadrado.Imprimir();
                }
            }
        }

    }
}
