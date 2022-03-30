using System;
namespace Unidad1Ej03_02
{
    public class Vagon
    {
        public Vagon()
        {
            this.Ruedas = new Rueda[]
            {
                new Rueda(),
                new Rueda(),
                new Rueda(),
                new Rueda()
            };
        }
        public string Color { set; get; }
        public int Largo { set; get; }
        public Rueda[] Ruedas { set; get; }
    }
}
