using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximoConexiones
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexion conexion = Conexion.Instance;            
            conexion.Enviar("hola");
            Conexion.ListaConexiones();
            conexion.Estado = Estados.Libre;
            
            Conexion.ListaConexiones();

            //Se ocupan las tres conexiones disponibles.
            conexion = Conexion.Instance;
            conexion = Conexion.Instance;
            conexion = Conexion.Instance;                        
            Conexion.ListaConexiones();

            Console.ReadLine();
        }
    }
}
