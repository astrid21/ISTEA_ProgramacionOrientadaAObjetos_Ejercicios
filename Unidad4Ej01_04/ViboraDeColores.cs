using System;
namespace Unidad4Ej01_04
{
    public class ViboraDeColores : Vibora
    {
        public ViboraDeColores(int xCabeza, int yCabeza) : base(xCabeza, yCabeza) { }

        public override void Mover()
        {
            ConsoleColor color = (DateTime.Now.Second % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Yellow;
            foreach (Asterisco asterisco in _Asteriscos)
            {
                asterisco.Color = color;
            }
            base.Mover();
        }
    }
}
