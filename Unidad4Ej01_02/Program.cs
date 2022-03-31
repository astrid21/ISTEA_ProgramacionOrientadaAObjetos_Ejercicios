using System;

namespace Unidad4Ej01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona personaReggini = new Persona();
            personaReggini.Edad = 40;
            personaReggini.Nombre = "Horacio Reggini"; //¿Quien es Horacio Reggini?
            personaReggini.Imprimir();

            Console.WriteLine("*****************************");

            Empleado empleadoSadosky = new Empleado();
            empleadoSadosky.Edad = 67;
            empleadoSadosky.Nombre = "Manuel Sadosky"; //¿Quien fue Manuel Sadosky?
            empleadoSadosky.Sueldo = 200000;
            empleadoSadosky.Imprimir();

            Console.WriteLine("*****************************");

            /* Notemos la conversión implícita de un objeto del 
            tipo “Empleado” a un objeto del tipo “Persona”. */
            Persona personaSadosky = empleadoSadosky;
            personaSadosky.Imprimir();

            Console.ReadKey();
        }
    }
}
