using System;
namespace EjercicioHerencia
{
    class EmpleadoEnNegro : Persona, IEmpleado
    {
        public int Legajo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Sueldo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MostrarInfo()
        {
            throw new NotImplementedException();
        }

        public void MostrarSueldo()
        {
            throw new NotImplementedException();
        }
    }
}
