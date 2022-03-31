using System;
namespace Unidad4Ej01_03
{
    public class Empleado
    {
        public int Legajo { set; get; }
        public Empleado(int legajo)
        {
            this.Legajo = legajo;
        }

        public virtual void Imprimir()
        {
            Console.WriteLine("Nro de legajo: " + this.Legajo);
        }
    }
}
