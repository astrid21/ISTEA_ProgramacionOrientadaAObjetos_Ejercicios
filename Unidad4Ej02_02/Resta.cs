using System;
namespace Unidad4Ej02_02
{
     class Resta:Operacion
    {

        public override void Operar()
        {
            this.Resultado = this.Valor1 - this.Valor2;
        }
    }
}
