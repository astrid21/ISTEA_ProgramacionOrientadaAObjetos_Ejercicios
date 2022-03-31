using System;
namespace Unidad4Ej01_04
{
    public class ViboraReductora : Vibora
    {
        public ViboraReductora(int xCabeza, int yCabeza) : base(xCabeza, yCabeza) { }

        public override void Mover()
        {
            if (_Asteriscos.Count != 1)
            {
                _Asteriscos[_Asteriscos.Count - 1].Borrar();
                _Asteriscos.RemoveAt(_Asteriscos.Count - 1);
            }
            base.Mover();
        }
    }
}
