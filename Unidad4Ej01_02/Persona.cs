using System;
namespace Unidad4Ej01_02
{
    public class Persona
    {
        public string Nombre { set; get; }
        public  int Edad { set; get; }

        public virtual void Imprimir()
        {
            Console.WriteLine("Nombre: " + this.Nombre);
            Console.WriteLine("Edda: " + this.Edad);
        }


    }
}
