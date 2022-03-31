using System;
using System.Collections.Generic;

namespace Unidad3Ej03_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Altas();
            program.Bajas();
            program.Modificaciones();

            program.AltasConForEnLugarDeforeach();
            program.BajasConForEnLugarDeforeach();
            program.ModificacionesConForEnLugarDeforeach();

            program.LibrosAltas();
            program.LibrosBajas();
            program.LibrosModificaciones();

            Console.WriteLine("Presione cualquier tecla para finalizar.");
            Console.ReadKey();
        }

        #region Altas, bajas y modificaciones sobre una lista de strings utilizando “foreach”.
        /// <summary>
        /// Solución al ejercicio: 1
        /// </summary>
        private void Altas()
        {
            List<string> textosAdicionados = new List<string>();
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");
            foreach (string texto in textos)
            {
                if (texto.Contains("hola"))
                    textosAdicionados.Add(texto.Replace("hola", "chau"));
            }
            textos.AddRange(textosAdicionados);
        }

        /// <summary>
        /// Solución al ejercicio: 2
        /// </summary>
        private void Bajas()
        {
            List<string> textosASerEliminados = new List<string>();
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");
            foreach (string texto in textos)
            {
                if (texto.Contains("hola"))
                {
                    textosASerEliminados.Add(texto);
                }
            }

            foreach (string texto in textosASerEliminados)
            {
                //Remueve de la lista de textos, el texto que cumple con la condición.
                textos.Remove(texto);
            }
        }

        /// <summary>
        /// Solución al ejercicio: 3
        /// </summary>
        private void Modificaciones()
        {
            List<int> indicesItemsAmodificar = new List<int>();
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");
            int i = 0;
            foreach (string texto in textos)
            {
                if (texto.Contains("hola"))
                    indicesItemsAmodificar.Add(i);
                i++;
            }
            foreach (int indice in indicesItemsAmodificar)
            {
                textos[indice] = textos[indice].Replace("hola", "chau");
            }
        }
        #endregion

        #region Altas, bajas y modificaciones sobre una lista de strings utilizando “for” en lugar de ""foreach.
        /// <summary>
        /// Solución al ejercicio: 4 Altas
        /// </summary>
        private void AltasConForEnLugarDeforeach()
        {
            List<string> textosAdicionados = new List<string>();
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");

            int count = textos.Count;

            for (int i = 0; i < count; i++)
            {
                if (textos[i].Contains("hola"))
                {
                    string textoConChau = textos[i].Replace("hola", "chau");
                    textos.Add(textoConChau);
                }
            }
        }

        /// <summary>
        /// Solución al ejercicio: 4 Bajas
        /// </summary>
        private void BajasConForEnLugarDeforeach()
        {
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");
            for (int i = 0; i < textos.Count; i++)
            {
                if (textos[i].Contains("hola"))
                {
                    textos.Remove(textos[i]);
                    i = -1;
                }
            }
        }

        /// <summary>
        /// Solución al ejercicio: 4 Modificaciones
        /// </summary>
        private void ModificacionesConForEnLugarDeforeach()
        {
            List<string> textos = new List<string>();
            textos.Add("hola mundo");
            textos.Add("le dijo hola");
            textos.Add("gracias totales");
            textos.Add("hola, soy un ladron");
            for (int i = 0; i < textos.Count; i++)
            {
                textos[i] = textos[i].Replace("hola", "chau");
            }
        }
        #endregion

        #region Altas, bajas y modificaciones sobre una lista de libros utilizando “foreach”.
        /// <summary>
        /// Solución al ejercicio: 6 Altas
        /// </summary>
        private void LibrosAltas()
        {
            List<Libro> librosAdicionados = new List<Libro>();

            List<Libro> libros = new List<Libro>();
            libros.Add(new Libro("hola mundo"));
            libros.Add(new Libro("le dijo hola"));
            libros.Add(new Libro("gracias totales"));
            libros.Add(new Libro("hola, soy un ladron"));

            foreach (Libro libro in libros)
            {
                if (libro.Texto.Contains("hola"))
                {
                    string textoNuevo = libro.Texto.Replace("hola", "chau");
                    librosAdicionados.Add(new Libro(textoNuevo));
                }
            }

            libros.AddRange(librosAdicionados);
        }

        /// <summary>
        /// Solución al ejercicio: 6 Bajas
        /// </summary>
        private void LibrosBajas()
        {
            List<Libro> librosASerEliminados = new List<Libro>();
            List<Libro> libros = new List<Libro>();
            libros.Add(new Libro("hola mundo"));
            libros.Add(new Libro("le dijo hola"));
            libros.Add(new Libro("gracias totales"));
            libros.Add(new Libro("hola, soy un ladron"));
            foreach (Libro libro in libros)
            {
                if (libro.Texto.Contains("hola"))
                {
                    librosASerEliminados.Add(libro);
                }
            }

            foreach (Libro libro in librosASerEliminados)
            {
                //Remueve de la lista de libros, el libro que cumple con la condición.
                libros.Remove(libro);
            }
        }

        /// <summary>
        /// Solución al ejercicio: 6 Modificaciones
        /// </summary>
        private void LibrosModificaciones()
        {
            List<int> indicesItemsAmodificar = new List<int>();
            List<Libro> libros = new List<Libro>();
            libros.Add(new Libro("hola mundo"));
            libros.Add(new Libro("le dijo hola"));
            libros.Add(new Libro("gracias totales"));
            libros.Add(new Libro("hola, soy un ladron"));
            int i = 0;
            foreach (Libro libro in libros)
            {
                if (libro.Texto.Contains("hola"))
                    indicesItemsAmodificar.Add(i);
                i++;
            }
            foreach (int indice in indicesItemsAmodificar)
            {
                string texto = libros[indice].Texto.Replace("hola", "chau");
                Libro libro = new Libro(texto);
                libros[indice] = libro;
            }
        }
        #endregion    
    }
}
