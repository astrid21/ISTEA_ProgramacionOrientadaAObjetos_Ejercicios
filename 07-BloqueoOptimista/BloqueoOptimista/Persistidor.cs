using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace DataAccessLayer
{
    /// <summary>
    /// Su responsabilidad es la de guardar y recupera la información hacia y desde la base de datos.
    /// </summary>
    public class Persistidor
    {
        /// <summary>
        /// Persite un producto en la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        public bool Save(Producto producto)
        {
            bool success;

            if (producto.Id.HasValue)
                //EL producto existe, entonces se realiza su modificación.
                success = this.Update(producto);
            else
                //EL producto NO existe, entonces se persiste uno nuevo.
                success = this.Insert(producto);

            return success;
        }

        /// <summary>
        /// Inserta un nuevo Producto en la tabla Producto
        /// </summary>
        /// <remarks>
        /// Primero y siguiendo el orden de las acciones CRUD
        /// Crearemos un Método que se encarga de insertar un nuevo Producto es nuestra tabla Producto
        /// </remarks>
        /// <param name="producto">Entidad contenedora de los valores a insertar</param>
        private bool Insert(Producto producto)
        {
            bool success;
            producto.Bloqueo = Guid.NewGuid().ToString();
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    @"INSERT INTO Producto 
                                (Marca, Precio, Bloqueo) 
                      VALUES 
                                (@marca, @precio, @bloqueo)";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@bloqueo", producto.Bloqueo);
                    
                    int count = cmd.ExecuteNonQuery();
                    success = (count == 1);
                }
            }

            this.SetProductoID(producto);
            return success;
        }

        /// <summary>
        /// Actualiza el Producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        private bool Update(Producto producto)
        {
            this.BloqueoPrecondition(producto);

            bool success = this.UpdateSinBloqueo(producto);
            
            return success;
        }

        /// <summary>
        /// Evalúa la existencia de un posible bloqueo OPTIMISTA de un registro.
        /// </summary>
        /// <param name="producto"></param>
        private void BloqueoPrecondition(Producto producto)
        {
            Producto productoEnBaseDeDatos = this.GetByid(producto.Id.Value);
            if (producto.Bloqueo != productoEnBaseDeDatos.Bloqueo)
                throw new BloqueoException();
        }

        /// <summary>
        /// Actualiza el Producto correspondiente al Id 
        /// proporcionado sin tener en cuanta bloqueo alguno.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        private bool UpdateSinBloqueo(Producto producto)
        {
            bool success;
            producto.Bloqueo = Guid.NewGuid().ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    @"  UPDATE Producto 
                        SET  
                            Marca = @marca, 
                            Precio = @precio,
                            Bloqueo = @bloqueo 
                        WHERE Id = @id";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@bloqueo", producto.Bloqueo);
                    cmd.Parameters.AddWithValue("@id", producto.Id);

                    int count = cmd.ExecuteNonQuery();
                    success = (count == 1);
                }
            }

            return success;
        }

        /// <summary>
        /// Representa una infracción por bloqueo de registro.
        /// </summary>
        public class BloqueoException : Exception { }

        /// <summary>
        /// Establece el valor de la propiedad Id de un producto.
        /// </summary>
        /// <param name="producto"></param>
        private void SetProductoID(Producto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery = @"SELECT MAX(id) FROM Producto";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    DataTable dataTable = new DataTable();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        producto.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        /// <summary>
        /// Devuelve un Objeto Producto
        /// </summary>
        /// <param name="idProducto">Id del producto a buscar</param>
        /// <returns>Un registro con los valores del Producto</returns>
        public Producto GetByid(int idProducto)
        {
            Producto producto = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM Producto WHERE Id = @id";
                using (OleDbCommand cmd = new OleDbCommand(sqlGetById, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    OleDbDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        producto = new Producto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDouble(dataReader["Precio"]),
                            Bloqueo = Convert.ToString(dataReader["Bloqueo"])
                        };
                    }
                }
            }
            return producto;
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idproducto">Id del registro a Eliminar</param>
        public void Delete(int idproducto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Producto WHERE Id = @id";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idproducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un OleDbDataAdapter.
        /// </remarks>
        /// <returns>Lista de productos</returns>
        public List<Producto> GetAll()
        {
            List<Producto> productos = new List<Producto>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Producto ORDER BY Id ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Marca = Convert.ToString(row["Marca"]),
                            Precio = Convert.ToDouble(row["Precio"]),
                            Bloqueo = Convert.ToString(row["Bloqueo"])
                        };
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }
    }
}
