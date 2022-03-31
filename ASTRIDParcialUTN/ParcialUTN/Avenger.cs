using System;
using System.Collections.Generic;
using System.Text;

namespace ParcialUTN
{
    class Avenger : Personaje
    {
        public Avenger(string nombre, List<EHabilidades> hab, EEquipamiento equipo):base(nombre,hab)
        {
            this.equipamiento = equipo;
        }

        private EEquipamiento equipamiento;

        public override string Nombre
        {
            get
            {
                
                return ("Mi nombre es" + this.Nombre + "y si no puedo y si no puedo proteger " +
                    "la tierra, la vengaré");
            }
        }

        public override string ToString()
        {
            StringBuilder todo = new StringBuilder();
            todo.Append(base.ToString());
            todo.Append("iii. equipamiento: "+this.equipamiento);

            return todo.ToString();
        }

    }
}
