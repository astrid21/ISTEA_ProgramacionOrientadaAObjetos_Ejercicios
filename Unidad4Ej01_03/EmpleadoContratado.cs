using System;
namespace Unidad4Ej01_03
{
    public class EmpleadoContratado:Empleado
    {

        public EmpleadoContratado(int legajo, int nroContrato):base(legajo)
        {
            this.NroContrato = nroContrato;
        }

        public int NroContrato { set; get; }

        public override void Imprimir()
        {
            base.Imprimir();
            Console.WriteLine("Nro de contrato: " + NroContrato);
        }
    }
}
