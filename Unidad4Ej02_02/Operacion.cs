using System;
namespace Unidad4Ej02_02
{
    abstract class Operacion
    {
        


        public int Valor1 { set; get; }
        public int Valor2 { set; get; }
        public int Resultado { set; get; }

        public abstract void Operar();

    }
}
