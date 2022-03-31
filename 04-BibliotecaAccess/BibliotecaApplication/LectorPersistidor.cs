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
    public class LectorPersistidor : ILibroPersistidor<Lector>
    {
        /// <summary>
        /// Persite un lector en la base de datos.
        /// </summary>
        /// <param name="lector"></param>
        public void Save(Lector lector)
        {
            if (lector.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(lector);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(lector);         
        }

        /// <summary>
        /// Inserta un nuevo Lector en la tabla Lector
        /// </summary>
        /// <param name="lector">Entidad contenedora de los valores a insertar</param>
        private void Insert(Lector lector)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    @"INSERT INTO Lector 
                                (dni, apellido) 
                      VALUES 
                                (@dni, @apellido)";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@dni", lector.DNI);
                    cmd.Parameters.AddWithValue("@apellido", lector.Apellido);                

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(lector);           
        }

        /// <summary>
        /// Actualiza el Lector correspondiente al Id proporcionado
        /// </summary>
        /// <param name="lector">Valores utilizados para hacer el Update al registro</param>
        private void Update(Lector lector)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    @"  UPDATE Lector 
                        SET  
                            dni = @dni, 
                            apellido = @apellido                                       
                        WHERE id_lector = @id_lector";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@dni", lector.DNI);
                    cmd.Parameters.AddWithValue("@apellido", lector.Apellido);
                    cmd.Parameters.AddWithValue("@id_lector", lector.Id);
              
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }            
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un Lector.
        /// </summary>
        /// <param name="lector"></param>
        private void SetID(Lector lector)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery = @"SELECT MAX(id_lector) FROM Lector";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    DataTable dataTable = new DataTable();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        lector.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

        /// <summary>
        /// Busca un lector por su clave primaria.
        /// </summary>
        /// <param name="idLector"></param>
        /// <returns></returns>
        public Lector GetByid(int idLector)
        {
            Lector lector = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                const string sqlQuery = "SELECT * FROM Lector WHERE id_lector = @id_lector";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id_lector", idLector);
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        lector = new Lector
                        {
                            Id = Convert.ToInt32(row["id_lector"]),
                            DNI = Convert.ToInt32(row["dni"]),
                            Apellido = Convert.ToString(row["apellido"])
                        };                       
                    }
                }
            }
            return lector;
        }
        
        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int idLector)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Lector WHERE id_lector = @id_lector";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id_lector", idLector);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista con todos los lectores ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <remarks>
        /// Utiliza un OleDbDataAdapter.
        /// </remarks>
        /// <returns>Lista de lectores</returns>
        public List<Lector> GetAll()
        {
            List<Lector> lectores = new List<Lector>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Lector ORDER BY id_lector ASC";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Lector lector = new Lector
                        {
                            Id = Convert.ToInt32(row["id_lector"]),
                            DNI = Convert.ToInt32(row["dni"]),
                            Apellido = Convert.ToString(row["apellido"])                           
                        };
                        lectores.Add(lector);
                    }
                }
            }
            return lectores;
        }
    }
}
