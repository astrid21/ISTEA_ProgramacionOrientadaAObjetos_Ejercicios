using System;
using System.Collections.Generic;

namespace Unidad1Ej03_03
{
    public class Espacio
    {
        //public Espacio()
        //{
            
        //}

        public bool HayCoalicion(Nave nave, List<Roca> Rocas)
        {
            bool HayCoalicion = false;
            foreach (Roca auxRoca in Rocas)
            {
                if(nave.CoordX == auxRoca.CoordX && nave.CoordY == auxRoca.CoordY)
                {
                    HayCoalicion = true;
                    break;
                }
            }

            return HayCoalicion;
        }
    }
}
