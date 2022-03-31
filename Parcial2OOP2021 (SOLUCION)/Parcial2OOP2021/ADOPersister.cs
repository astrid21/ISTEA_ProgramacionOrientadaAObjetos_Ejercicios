using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Parcial2OOP2021
{
    public class ADOPersister : IPersistible
    {
        public static string ConnectionString { set; get; }

        public List<Cliente> SearchByApellido(string partOfApellido)
        {
            List<Cliente> Clientes = new List<Cliente>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @"SELECT * 
                                                FROM Clientes 
                                                WHERE Apellido 
                                                LIKE '%' + @Apellido + '%'";

                    sqlCommand.Parameters.AddWithValue("@Apellido", partOfApellido);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table); //Se ejecuta el Select

                    Clientes = GetClientesFromTable(table);
                }
            }

            if (Clientes.Count == 0)
            {
                //Lanza la excepción indicando que no existen Clientes que cumplan con lo requerido.
                string msgError = "No se encontraron Cliente que cumplan con {0}";
                msgError = string.Format(msgError, partOfApellido);                
                throw new ClienteNoEncontradoException(msgError);
            }
            
            return Clientes;
        }

        /// <summary>
        /// Carga una lista de Clientes leyéndolos desde una tabla.
        /// </summary>
        /// <param name="table">
        /// Tabla desde la que se leerán los Clientes.
        /// </param>
        /// <returns>
        /// Colección de Clientes.
        /// </returns>
        private List<Cliente> GetClientesFromTable(DataTable table)
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (DataRow row in table.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(row["ID"]);
                cliente.Apellido = row["Apellido"].ToString();
                cliente.DNI = Convert.ToInt32(row["DNI"]);
                cliente.Deuda = Convert.ToInt32(row["Deuda"]);

                clientes.Add(cliente);
            }
            return clientes;
        }

        public Cliente Get(int id)
        {
            Cliente ClienteWithID = null;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @"SELECT * 
                                                FROM Clientes 
                                                WHERE ID = @ID 
                                                ";

                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);

                    if (table.Rows.Count != 1)
                    {
                        //Lanza la excepción indicando que no existen Clientes que cumplan con lo requerido.
                        string msgError = "No se encontraron clientes que cumplan con id = {0}";
                        msgError = string.Format(msgError, id);                        
                        throw new ClienteNoEncontradoException(msgError);
                    }
                    
                    List<Cliente> Clientes = new List<Cliente>();
                    Clientes = GetClientesFromTable(table);
                    ClienteWithID = Clientes[0];

                }
            }
            return ClienteWithID;
        }

        public void Remove(int id)
        {
            RemovePreCondicion(id);

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @" DELETE 
                                                    Clientes
                                                WHERE 
                                                    ID = @ID
                                            ";

                    sqlCommand.Parameters.AddWithValue("@ID", id);

                    int recordsAffected = sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente el DELETE

                    if (recordsAffected != 1)
                    {
                        //Lanza la excepción indicando que no existen Clientes que cumplan con lo requerido.
                        string msgError = "No se encontraron Cliente que cumplan con id = {0}";
                        msgError = string.Format(msgError, id);
                        throw new ClienteNoEncontradoException(msgError);
                    }                    
                }
            }
        }

        /// <summary>
        /// Evalúa que el cliente no posea deuda.
        /// </summary>
        /// <exception cref="ClienteConDeudaException">
        /// </exception>
        /// <param name="id"></param>
        private void RemovePreCondicion(int id)
        {           
            Cliente cliente = this.Get(id);
            if (cliente.Deuda != 0)
            {
                string msg = "El cliente no puede ser eliminado ya que adeuda {0} pesos.";
                msg = string.Format(msg, cliente.Deuda);                
                throw new ClienteConDeudaException(msg);
            }                
        }

        public void Remove(Cliente cliente)
        {
            #region Evalua la PreCondicion
            if (cliente == null) throw new ArgumentNullException();
            if (!cliente.Id.HasValue) throw new ClienteIdIsNullException();
            #endregion
            
            this.Remove(cliente.Id.Value);
        }

        private void Update(Cliente Cliente)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = @" UPDATE Cliente
                                                SET 
                                                    Apellido = @Apellido,
                                                    DNI = @DNI,
                                                    Deuda = @Deuda
                                                WHERE ID = @ID";

                    sqlCommand.Parameters.AddWithValue("@Apellido", Cliente.Apellido);
                    sqlCommand.Parameters.AddWithValue("@DNI", Cliente.DNI);
                    sqlCommand.Parameters.AddWithValue("@Deuda", Cliente.Deuda);
                    sqlCommand.Parameters.AddWithValue("@ID", Cliente.Id.Value);

                    int recordsAffected = sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente UPDATE

                    if (recordsAffected == 0) throw new Exception("El registro a modificar no existe.");
                }
            }
        }

        /// <summary>
        /// Alta de un Cliente.
        /// </summary>
        /// <param name="Cliente"></param>
        private void InsertOne(Cliente Cliente)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand();            
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Connection.Open();
            sqlCommand.CommandText = @"INSERT INTO Clientes
                                    ([Apellido]
                                    ,[DNI]
                                    ,[Deuda])
                                VALUES
                                    (@Apellido,
                                        @DNI,
                                        @Deuda)";

            sqlCommand.Parameters.AddWithValue("@Apellido", Cliente.Apellido);
            sqlCommand.Parameters.AddWithValue("@DNI", Cliente.DNI);
            sqlCommand.Parameters.AddWithValue("@Deuda", Cliente.Deuda);

            sqlCommand.ExecuteNonQuery(); //Se ejecuta realmente el INSERT INTO

            Cliente.Id = GetId(sqlCommand);

            sqlCommand.Connection.Close();            
        }

        /// <summary>
        /// Consulta por el valor del ID.
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        private int GetId(SqlCommand sqlCommand)
        {
            sqlCommand.CommandText = "Select @@IDENTITY";
            sqlCommand.Parameters.Clear();

            object objID = sqlCommand.ExecuteScalar();

            int id = Convert.ToInt32(objID);

            return id;
        }

        public List<Exception> Insert(List<Cliente> Clientes)
        {
            List<Exception> errors = new List<Exception>();
            if (Clientes != null)
            {
                foreach (Cliente product in Clientes)
                {
                    try
                    {
                        InsertOne(product);
                        errors.Add(null);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(ex);
                    }
                }
            }
            return errors;
        }

        public void RenumerarPorID()
        {
            //Foto
            List<Cliente> fotoClientes = this.SearchByApellido("");
            
            //Elimino todos los clientes
            foreach(Cliente cliente in fotoClientes)
            {
                this.Remove(cliente);
            }

            //Inserta los clientes de la foto
            this.Insert(fotoClientes);
        }
    }
}