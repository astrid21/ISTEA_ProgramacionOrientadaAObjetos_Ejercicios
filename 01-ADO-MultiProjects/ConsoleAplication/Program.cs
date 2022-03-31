using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace ConsoleProducto
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo comando;
            do
            {
                comando = Menu();
                switch (comando.Key)
                {
                    case ConsoleKey.N:
                        Nuevo();
                        break;
                    case ConsoleKey.M:
                        Modificar();
                        break;
                    case ConsoleKey.B:
                        Borrar();
                        break;
                    case ConsoleKey.L:
                        Listar();
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            } while (comando.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Lista los productos existentes en la base de datos por pantalla.
        /// </summary>
        static void Listar()
        {
            Console.Clear();
            Console.WriteLine("{0}\t\t{1}\t\t\t{2}", "Id", "Marca", "Precio");
            Console.WriteLine("{0}\t\t{1}\t\t\t{2}", "--", "-----", "------");
            Persistidor persistidor = new Persistidor();
            List<Producto> productos = persistidor.GetAll();
            foreach (Producto producto in productos)
            {
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}", producto.Id, producto.Marca, producto.Precio);            
            }
            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        /// <summary>
        /// Elimina un producto de la base de datos.
        /// </summary>
        static void Borrar()
        {
            Console.Clear();
            Console.Write("Id:");
            string dato = Console.ReadLine();
            int id = int.Parse(dato);
            
            if (IsAceptar())
            {
                Persistidor persistidor = new Persistidor();
                persistidor.Delete(id);
            }
        }

        /// <summary>
        /// Modifica un producto en la base de datos.
        /// </summary>
        static void Modificar()
        {
            Producto producto = ReadFromUI(false);
            if (IsAceptar())
            {
                Persistidor persistidor = new Persistidor();
                bool exito = persistidor.Save(producto);
                if (exito)
                    ImprimirMensaje("El producto ha sido modificado con éxito.");
                else
                    ImprimirMensaje("El producto NO existe.");
            }
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos.
        /// </summary>
        static void Nuevo()
        {
            Producto producto = ReadFromUI(true);
            if(IsAceptar())
            {
                Persistidor persistidor = new Persistidor();
                persistidor.Save(producto);
                ImprimirMensaje("El id del nevo producto es:" + producto.Id.ToString());
            }
        }

        /// <summary>
        /// Lee un producto ingresado por el usuario.
        /// </summary>
        /// <param name="esNuevoProducto">
        /// Indica si el producto a leer es existe o no en la base de datos.
        /// </param>
        /// <returns>
        /// Producto ingresado por el usuario.
        /// </returns>
        static Producto ReadFromUI(bool esNuevoProducto)
        {
            Console.Clear();
            Producto producto = new Producto();

            if (!esNuevoProducto)
            {
                #region Id
                Console.Write("Id:");
                string dato = Console.ReadLine();

                int? id;            //El id es un nullable int, acepat enteros y nulos.
                if (dato.Trim() == "")
                    id = null;
                else
                    id = int.Parse(dato);

                producto.Id = id;
                #endregion
            }
            else
            {
                producto.Id = null;   
            }

            Console.Write("Marca:");
            producto.Marca = Console.ReadLine();

            Console.Write("Precio:");
            producto.Precio = double.Parse(Console.ReadLine());

            return producto;
        }

        /// <summary>
        /// Pide al usuario una confirmación.
        /// </summary>
        /// <returns>
        /// Indica si confirma o cancela el comando.
        /// </returns>
        static bool IsAceptar()
        {
            bool aceptar;
            //Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Enter-Aceptar comando");
            Console.WriteLine("Esc-Salir");

            ConsoleKeyInfo comando = Console.ReadKey();
            aceptar = (comando.Key == ConsoleKey.Enter) ? true : false;
            return aceptar;
        }

        /// <summary>
        /// Muestra el menú de comandos al usuario.
        /// </summary>
        /// <returns>
        /// La tecla que representa el comando ingresado.
        /// </returns>
        static ConsoleKeyInfo Menu()
        {
            Console.Clear();
            Console.WriteLine("n   -Nuevo");
            Console.WriteLine("m   -Modificar");
            Console.WriteLine("b   -Borrar");
            Console.WriteLine("l   -Listar");
            Console.WriteLine("Esc -Finalizar");
            Console.WriteLine();
            ConsoleKeyInfo comando = Console.ReadKey();            
            return comando;
        }

        /// <summary>
        /// Muestra un mensaje al usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        static void ImprimirMensaje(string mensaje)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(mensaje);
            Console.ReadKey();
        }
    }
}
