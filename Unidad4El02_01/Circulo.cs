using System;
namespace Unidad4El02_01
{
    class Circulo : FiguraGeometrica
    {
        public double  Radio { set; get; }

        public Circulo(double radio)
        {
            this.Radio = radio;
        }

        public override double Area()
        {
            double resul = (this.Radio * this.Radio) * Math.PI;
            return resul;
        }
    }
}
