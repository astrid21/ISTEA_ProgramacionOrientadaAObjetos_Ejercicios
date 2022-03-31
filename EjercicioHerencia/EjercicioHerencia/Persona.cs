using System;
namespace EjercicioHerencia
{
    public class Persona
    {
        public int DNI { set; get; }
        public string Apellido { set; get; }

        public void Caminar()
        {
            Console.WriteLine("Caminar");
        }

        public virtual void DecirAlgo()
        {
            Console.WriteLine("soy una persona");
        }
        public virtual void DecirAlgo2()
        {
            Console.WriteLine("soy una persona");
        }
    }
}
