using System;
namespace Unidad4Ej02_02
{
     class Suma:Operacion
    {
        

        public override void Operar()
        {
            this.Resultado = this.Valor1 + this.Valor2;
        }
    }
}
