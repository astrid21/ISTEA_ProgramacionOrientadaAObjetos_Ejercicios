using System;
namespace EjercicioHerencia
{
    sealed class Alumno : Persona
    {
        public int NroMatricula { set; get; }
        public string EmailEscuela { set; get; }

        public Alumno(int dni)
        {
            base.DNI = dni;
            
        }

        public void Estudiar()
        {
            Console.WriteLine("Estudiar");
        }

        public override void DecirAlgo()
        {
            base.DecirAlgo();
            Console.WriteLine("soy un alumno");
        }

        public new void DecirAlgo2()
        {
            Console.WriteLine("soy un alumno");
        }
    }
}
