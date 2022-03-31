using System;
using System.Collections.Generic;
using System.Text;


namespace ParcialUTN
{
    static class Marvel
    {
        static Marvel()
        {
            listaPersonajes = new List<Personaje>();
        }

        static private List<Personaje> listaPersonajes;

        static public Personaje Personaje
        {
            set
            {
                listaPersonajes += value;
            }
        }

        static public void MostrarInformacion()
        {
            
            foreach (Personaje p in listaPersonajes)
            {
                if(p is Avenger)
                {
                    Console.WriteLine("****** AVENGER ******");
                    Console.WriteLine(p.ToString());
                }
                else
                {
                    Console.WriteLine("****** ENEMIGO ******");
                    Console.WriteLine(p.ToString());
                }

                
            }

            
        }
    }
}
