using System;
namespace Unidad1Ej03_02
{
    public class Maquina
    {
        public string Color { set; get; }
        public int Largo { set; get; }
        public Rueda[] Ruedas { set; get;}

        public Maquina()
        {
            this.Ruedas = new Rueda[] {
                                        new Rueda(),
                                        new Rueda(),
                                        new Rueda(),
                                        new Rueda(),
                                        new Rueda(),
                                        new Rueda()
            };
        }
    }
}
