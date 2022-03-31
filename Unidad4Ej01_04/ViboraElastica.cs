using System;
namespace Unidad4Ej01_04
{
    public class ViboraElastica:Vibora
    {
        public ViboraElastica(int xCabeza, int yCabeza) : base(xCabeza, yCabeza) { }

        public override void Mover()
        {
            Asterisco ultimoAsterisco = _Asteriscos[_Asteriscos.Count - 1];
            Asterisco nuevoAsterisco = new Asterisco();
            nuevoAsterisco.X = ultimoAsterisco.X;
            nuevoAsterisco.Y = ultimoAsterisco.Y;
            nuevoAsterisco.Color = ConsoleColor.Green;
            base.Mover();
            if (DateTime.Now.Second % 3 == 0)
            {
                _Asteriscos.Add(nuevoAsterisco);
            }
        }
    }
}
