using System;
namespace Unidad4El02_01
{
    class Triangulo:FiguraGeometrica
    {
        public Triangulo(double @base, double  altura)
        {
            this.Base = @base;
            this.Altura = altura;
        }
        public double Base { set; get; }
        public double Altura { set; get; }

        public override double Area()
        {
            return (double)(this.Base*this.Altura/2);
        }
    }
}
