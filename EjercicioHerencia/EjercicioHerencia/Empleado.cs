using System;
namespace EjercicioHerencia
{
    public interface IEmpleado
    {
        public abstract int Legajo { set; get; }
        public abstract int Sueldo { set; get; }

        public abstract void MostrarInfo();


        public abstract void MostrarSueldo();
    }
}
