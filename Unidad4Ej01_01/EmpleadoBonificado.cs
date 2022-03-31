using System;
namespace Unidad4Ej01_01
{
    public class EmpleadoBonificado : Empleado
    {
        public int Bono { set; get; }

        public override int CalcularSueldo()
        {
            int sueldo = this.SueldoBase + this.Bono;
            return sueldo;
        }
    }
}
