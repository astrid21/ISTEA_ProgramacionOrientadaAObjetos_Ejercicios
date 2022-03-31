using System;
using System.Collections.Generic;
using System.Text;

namespace ParcialUTN
{
    abstract class Personaje
    {


        private Personaje()
        {
            listaHabilidades = new List<EHabilidades>();
        }

        public Personaje(string nombre, List<EHabilidades> habilidades):this()
        {
            this.nombre = nombre;
            this.listaHabilidades = habilidades;
        }

        private List<EHabilidades> listaHabilidades;

        private string nombre;


        private string ListaHabilidades
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                foreach (EHabilidades eh in listaHabilidades)
                {
                   
                    sb.Append(eh.ToString() + " ");
                }

                return sb.ToString();
            }
        }

        public abstract string Nombre {  get; }

        public static bool operator !=(List<Personaje> personajes, Personaje personaje)

        {
            bool NoEncontrado = true;

            foreach (Personaje p in personajes)
            {
                if (p.GetType() == personaje.GetType() && p.Nombre == personaje.Nombre)
                {
                    NoEncontrado = false;
                }
            }


            return NoEncontrado;

        }

        public static bool operator ==(List<Personaje> personajes, Personaje personaje)

        {
            bool Encontrado = false;

            foreach (Personaje p in personajes)
            {
                if(p.GetType() == personaje.GetType() && p.Nombre == personaje.Nombre)
                {
                    Encontrado = true;
                }
            }

            return Encontrado;

        }

        public static List<Personaje> operator +(List<Personaje> personajes, Personaje personaje)

        {
            bool Encontrado = false;

            foreach (Personaje p in personajes)
            {
                if (personaje == p)
                {
                    Encontrado = true;
                }
            }

            if(Encontrado == false)
            {
                personajes.Add(personaje);
            }

            return personajes;

        }

        public override string ToString()
        {
            StringBuilder todo = new StringBuilder();
            todo.Append("i. Nombre: " + this.Nombre);
            todo.Append("ii. ListaHabilidades: " + this.ListaHabilidades);

            return todo.ToString();
        }

    }
}
