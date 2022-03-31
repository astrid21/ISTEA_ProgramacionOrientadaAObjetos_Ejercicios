using System;
namespace Unidad4El02_01
{
     class Cuadrado:FiguraGeometrica
    {
        public Cuadrado(double lado)
        {
            this.Lado = lado;
        }

        public double Lado { set; get; }

        public override double Area()
        {
            return (this.Lado * this.Lado);
        }
    }
}
