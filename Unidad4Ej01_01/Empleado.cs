using System;
namespace Unidad4Ej01_01
{
    public class Empleado
    {
        public string  Nombre { set; get; }
        public int SueldoBase { set; get; }

        public virtual int CalcularSueldo()
        {
            return this.SueldoBase;

        }
    }
}
