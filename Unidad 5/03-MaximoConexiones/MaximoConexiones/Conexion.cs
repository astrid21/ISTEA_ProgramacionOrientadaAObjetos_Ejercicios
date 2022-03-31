using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximoConexiones
{
    public sealed class Conexion 
    {
        /// <summary>
        /// Para que no se puedan crear instancias con new.
        /// </summary>
        private Conexion(int id, Estados estado) 
        {
            this.Id = id;
            this.Estado = estado;
        }        

        /// <summary>
        /// Esatdo actual de la conexion.
        /// </summary>
        public Estados Estado { set; get; }

        /// <summary>
        /// Identifica inequívocamente una conexión.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Envía un mensaje por la conexión.
        /// </summary>
        /// <param name="mensaje"></param>
        public void Enviar(string mensaje)
        {
            Console.WriteLine("Conexión: ‘{0}’ Envainado mensaje: ‘{1}’", this.Id, mensaje);                
        }

        /// <summary>
        /// Constructor estatico, inicializa los miembros estaticos.
        /// </summary>
        static Conexion()
        {
            _Conexiones = new List<Conexion>();
            _Conexiones.Add(new Conexion(0, Estados.Libre));
            _Conexiones.Add(new Conexion(1, Estados.Libre));
            _Conexiones.Add(new Conexion(2, Estados.Libre));
        }

        /// <summary>
        /// Retorna la primera conexión libre que encuentre, 
        /// si no existen conexiones libres lanza una excepción.
        /// </summary>
        public static Conexion Instance
        {
            get
            {
                Conexion conexionLibre = null;
                foreach (Conexion conexion in _Conexiones)
                {
                    if (conexionLibre == null)
                    {
                        if (conexion.Estado == Estados.Libre)
                        {
                            conexionLibre = conexion;
                            conexion.Estado = Estados.Ocupada;
                        }
                    }
                }
                if (conexionLibre == null) throw new Exception("Todas las conexiones están ocupadas.");
                return conexionLibre;
            }
        }

        /// <summary>
        /// Colección de conexiones.
        /// </summary>
        private static List<Conexion> _Conexiones;

        /// <summary>
        /// Libera todas las conexiones existentes.
        /// </summary>
        public static void LiberarConexiones()
        {
            foreach (Conexion conexion in _Conexiones)
            {
                conexion.Estado = Estados.Libre;
            }
        }

        /// <summary>
        /// Muestra por pantalla la colección de conexiones y sus estados.
        /// </summary>
        public static void ListaConexiones()
        {
            Console.WriteLine("LISTADO DE CONEXIONES.");
            foreach (Conexion conexion in _Conexiones)
            {
                Console.WriteLine("Id: {0} estado: {1}", conexion.Id, conexion.Estado);
            }
        }

        /// <summary>
        /// Retorna el número de conexiones que 
        /// actualmente están libres.
        /// </summary>
        /// <returns></returns>
        public static int CantidadConexionesLibres
        {
            get
            {
                int cantLibres = 0;
                foreach (Conexion conexion in _Conexiones)
                {
                    if (conexion.Estado == Estados.Libre)
                    {
                        cantLibres++;
                    }
                }
                return cantLibres;
            }
        }
    }
}
