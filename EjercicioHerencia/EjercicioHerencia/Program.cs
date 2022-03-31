using System;

namespace EjercicioHerencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno alumno = new Alumno(111111);
            alumno.DNI = 111111;
            alumno.Apellido = "Sadosky";
            alumno.NroMatricula = 22222;
            alumno.EmailEscuela = "MSadosky@escuela.com";

            Persona persona1 = alumno;
            // override
            alumno.DecirAlgo(); // soy un alumno
            persona1.DecirAlgo(); // soy un alumno

            // new
            alumno.DecirAlgo2(); // soy un alumno
            persona1.DecirAlgo2(); // soy una persona

            Console.ReadLine();
            if (alumno is Persona)
            {
                Console.WriteLine("El alumno pertenece a la clase persona");
            }
            Imprimir(alumno);

            
        }

        static void Imprimir(Persona persona)
        {
            Console.Write("DNI: ");
            Console.WriteLine(persona.DNI);

            Console.Write("Apellido: ");
            Console.WriteLine(persona.Apellido);

            Console.ReadLine();
        }
    }
}
