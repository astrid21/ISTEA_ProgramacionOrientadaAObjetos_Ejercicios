using System;
namespace Unidad4Ej01_02
{
    public class Empleado :  Persona
    {
        public float Sueldo { set; get; }
        public new void Imprimir()
        {
            base.Imprimir();
            Console.WriteLine("Sueldo: " + this.Sueldo);
        }
    }
}
