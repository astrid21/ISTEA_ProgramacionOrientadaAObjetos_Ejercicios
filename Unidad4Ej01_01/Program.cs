using System;

namespace Unidad4Ej01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = "Manuel Sadosky";
            empleado.SueldoBase = 100;

            EmpleadoBonificado empeleadoBonificado = new EmpleadoBonificado();
            empeleadoBonificado.Nombre = "Luis Federico Leloir";
            empeleadoBonificado.SueldoBase = 100;
            empeleadoBonificado.Bono = 50;

            EmpleadoPorHora empleadoPorHora = new EmpleadoPorHora();
            empleadoPorHora.Nombre = "José Antonio Balseiro";
            empleadoPorHora.SueldoBase = 240;
            empleadoPorHora.HorasTrabajadas = 16;

            Console.WriteLine("Sueldo del Empleado {0} es: {1}", empleado.Nombre, empleado.CalcularSueldo());
            Console.WriteLine("Sueldo del EmpeleadoBonificado: {0} es: {1}", empeleadoBonificado.Nombre, empeleadoBonificado.CalcularSueldo());
            Console.WriteLine("Sueldo del EmpeleadoPorHora: {0} es: {1}", empleadoPorHora.Nombre, empleadoPorHora.CalcularSueldo());

            Console.ReadKey();
        }
    }
    
}
