using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryADOPersister
{
    public class ADOPersister : IPersistible
    {
        public static string ConnectionString;

        public List<Producto> Find(string partOfDescription)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {                
                string sql = @" SELECT * 
                                FROM producto 
                                WHERE Descripcion LIKE '%' + @parte + '%'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@parte", partOfDescription);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    productos = CovertTableToList(table);
                }
            }
            return productos;
        }

        private List<Producto> CovertTableToList(DataTable table)
        {
            List<Producto> productos = new List<Producto>();
            foreach(DataRow row in table.Rows)
            {
                Producto producto = new Producto()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Descripcion = Convert.ToString(row["Descripcion"]),
                    Marca = Convert.ToString(row["Marca"]),
                    Precio = Convert.ToDouble(row["Precio"])
                };

                productos.Add(producto);
            }            
            return productos;
        }

        public Producto Load(int id)
        {
            Producto producto = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @" SELECT * 
                                FROM producto
                                WHERE id = @id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);

                    if (table.Rows.Count != 1) 
                        throw new Exception("Error por id erroneo");

                    List<Producto> productos = CovertTableToList(table);

                    producto = productos[0];
                }
            }
            return producto;
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @" DELETE 
                                FROM producto
                                WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros eliminado");
                }
            }
        }

        public void Remove(Producto producto)
        {
            this.Remove(producto.Id.Value);
        }

        public void Save(Producto producto)
        {
            if (producto.Id != null)
                Update(producto);
            else
                Insert(producto);            
        }

        private void Insert(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO [Producto]
                                ([Descripcion]
                                ,[Marca]
                                ,[Precio])
                               VALUES
                                (@Descripcion
                                ,@Marca
                                ,@Precio)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros insertados");

                    producto.Id = GetId(command);
                }
            }
        }

        private int GetId(SqlCommand command)
        {
            int id;
            string sql = "select @@identity";
            command.CommandText = sql;
            command.Parameters.Clear();
            object objId = command.ExecuteScalar();
            id = Convert.ToInt32(objId);
            return id;
        }

        private void Update(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = @"UPDATE [Producto]
                               SET [Descripcion] = @Descripcion 
                                  ,[Marca]       = @Marca
                                  ,[Precio]      = @Precio
                               WHERE id = @id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Marca", producto.Marca);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@id", producto.Id.Value);

                    int recordsAffected = command.ExecuteNonQuery();

                    if (recordsAffected != 1)
                        throw new Exception("Error en la cantidad de registros modificados");
                }
            }
        }

        /// <summary>
        /// Pasa los valores de los campos del registro cuyo id es idA, 
        /// al registro cuyo id es idB y viceversa.
        /// </summary>
        /// <exception cref="IdNoExisteException">
        /// El caso de que alguno de los dos IDs parámetros no exista (no existe el registro), 
        /// el método debe lanzar una excepción dl tipo ‘IdNoExisteException’ indicando en 
        /// su propiedad ‘Message’ el número del ID inexistente.         
        /// </exception>
        /// <remarks>
        /// En caso de que ambos IDs sean iguales, ambos parámetros iguales, el enroque 
        /// debe hacerse entre el ID pasado como parámetro y el del escritor que posea 
        /// el mayor de los IDs.
        /// </remarks>
        /// <param name="idA">primary key A</param>
        /// <param name="idB">primary key B</param>
        public void Enroque(int idA, int idB)
        {
            Producto pA;
            Producto pB;
            int idNoExiste = idA;

            //Para el caso de IDs iguales.
            if (idA == idB)
            {
                idB = GetMaxId();
            }

            #region Precondicion por existencia
            try
            {
                pA = this.Load(idA);
                idNoExiste = idB;

                pB = this.Load(idB);
            }
            catch (Exception)
            {
                string msgError = idNoExiste + " no existe.";
                throw new IdNoExisteException(msgError);
            }
            #endregion

            Producto pTemp = new Producto()
            {
                Id = pA.Id,
                Marca = pA.Marca,
                Precio = pA.Precio,
                Descripcion = pA.Descripcion
            };

            pA.Marca = pB.Marca;
            pA.Precio = pB.Precio;
            pA.Descripcion = pB.Descripcion;

            pB.Marca = pTemp.Marca;
            pB.Precio = pTemp.Precio;
            pB.Descripcion = pTemp.Descripcion;

            //Persitir a base de datos
            this.Save(pA);
            this.Save(pB);
        }

        /// <summary>
        /// Busca el ID mas grande.
        /// </summary>
        /// <returns></returns>
        private int GetMaxId()
        {
            int maxId;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = @" SELECT 
                                MAX(id) 
                                FROM producto";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    object objMaxId = command.ExecuteScalar();
                    maxId = Convert.ToInt32(objMaxId);
                }
            }

            return maxId;
        }
    }
}
