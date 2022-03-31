using System;
namespace Unidad4Ej01_01
{
    public class EmpleadoPorHora : Empleado
    {
        public int HorasTrabajadas { set; get; }


        public override int CalcularSueldo()
        {
            const int HORAS_DIAS = 24;
            int sueldo = (this.SueldoBase / HORAS_DIAS) * this.HorasTrabajadas;
            return sueldo;
        }
    }
}
