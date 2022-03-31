using System;
using System.Collections.Generic;
using System.Text;


namespace ParcialUTN
{
     class Enemigo:Personaje
    {
        public Enemigo(string nombre, List<EHabilidades> hab, string objetivo) : base(nombre, hab)
        {
            this.objetivo = objetivo;
        }

        private string objetivo;

        public override string Nombre
        {
            get
            {

                return ("Soy" + this.Nombre + "y los voy a hacer puré");
            }
        }

        public override string ToString()
        {
            StringBuilder todo = new StringBuilder();
            todo.Append(base.ToString());
            todo.Append("iii. objetivo: " + this.objetivo);

            return todo.ToString();
        }
    }
}
