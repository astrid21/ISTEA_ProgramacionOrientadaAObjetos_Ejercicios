using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Su responsabilidad es la de guardar y recupera la información hacia y desde la base de datos.
    /// </summary>
    public class LibroPersistidor : ILibroPersistidor<Libro>
    {
        /// <summary>
        /// Persite un libro en la base de datos.
        /// </summary>
        /// <param name="libro"></param>
        public void Save(Libro libro)
        {           
            if (libro.Id.HasValue)
                //La entidad existe, entonces se realiza su modificación.
                this.Update(libro);
            else
                //La entidad NO existe, entonces se persiste una nueva.
                this.Insert(libro);         
        }

        /// <summary>
        /// Inserta un nuevo libro en la tabla libro
        /// </summary>     
        /// <param name="libro">Entidad contenedora de los valores a insertar</param>
        private void Insert(Libro libro)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    @"INSERT INTO Libro 
                                (codigo_identificacion_unico, titulo, isbn, id_lector) 
                      VALUES 
                                (@codigo_identificacion_unico, @titulo, @isbn, @id_lector)";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    object idLector = libro.IdLector == null ? (object)DBNull.Value : libro.IdLector;

                    cmd.Parameters.AddWithValue("@codigo_identificacion_unico", libro.CodigoIdentificacionUnico);
                    cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@isbn", libro.ISBN);
                    cmd.Parameters.AddWithValue("@id_lector", idLector);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(libro);           
        }

        /// <summary>
        /// Actualiza el libro correspondiente al Id proporcionado
        /// </summary>
        /// <param name="libro">Valores utilizados para hacer el Update al registro</param>
        private void Update(Libro libro)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery =
                    @"  UPDATE Libro 
                        SET  
                            codigo_identificacion_unico = @codigo_identificacion_unico,
                            titulo = @titulo, 
                            isbn = @isbn,
                            id_lector = @id_lector                        
                        WHERE id_libro = @id_libro";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    object idLector = libro.IdLector == null ? (object)DBNull.Value : libro.IdLector;

                    cmd.Parameters.AddWithValue("@codigo_identificacion_unico", libro.CodigoIdentificacionUnico);
                    cmd.Parameters.AddWithValue("@titulo", libro.Titulo);
                    cmd.Parameters.AddWithValue("@isbn", libro.ISBN);
                    cmd.Parameters.AddWithValue("@id_lector", idLector);
                    cmd.Parameters.AddWithValue("@id_libro", libro.Id.Value);

                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }            
        }

        /// <summary>
        /// Establece el valor de la propiedad Id de un libro.
        /// </summary>
        /// <param name="libro"></param>
        private void SetID(Libro libro)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery = @"SELECT MAX(id_libro) FROM Libro";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        libro.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }
           
        /// <summary>
        /// Devuelve un Objeto Libro buscandolo por su clave primaria.
        /// </summary>
        /// <param name="idLibro"></param>
        /// <returns></returns>
        public Libro GetByid(int idLibro)
        {
            Libro libro = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                const string sqlQuery = "SELECT * FROM Libro WHERE id_libro = @id_libro";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id_libro", idLibro);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        libro = new Libro
                        {
                            Id = Convert.ToInt32(row["id_libro"]),
                            CodigoIdentificacionUnico = Convert.ToString(row["codigo_identificacion_unico"]),
                            Titulo = Convert.ToString(row["titulo"]),
                            ISBN = Convert.ToString(row["isbn"]),
                            IdLector = (row["id_lector"]) == DBNull.Value ? null : (int?)(row["id_lector"])
                        };
                    }
                }
            }
            return libro;
        }

        /// <summary>
        /// Devuelve un Objeto Libro por su isbn
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public Libro GetByIsbn(string isbn)
        {
            Libro libro = null;
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {                
                const string sqlQuery = "SELECT * FROM Libro WHERE isbn = @isbn";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if(table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        libro = new Libro
                        {
                            Id = Convert.ToInt32(row["id_libro"]),
                            Titulo = Convert.ToString(row["titulo"]),
                            ISBN = Convert.ToString(row["isbn"]),
                            IdLector = (row["id_lector"]) == DBNull.Value ? null : (int?)(row["id_lector"])
                        };                       
                    }
                }
            }
            return libro;
        }
    
        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idLibro">Id del registro a Eliminar</param>
        public void Delete(int idLibro)
        {
            this.DeletePreCondition(idLibro);

            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Libro WHERE id_libro = @id_libro";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id_libro", idLibro);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Evalúa la restricción que impide eliminar un libro que este prestado.
        /// </summary>
        /// <param name="idLibro"></param>
        private void DeletePreCondition(int idLibro)
        {
            Libro libro = this.GetByid(idLibro);
            if (libro.Prestado)
                throw new EliminarLibroPrestadoException(libro);
        }

        /// <summary>
        /// Se intentó eliminar un libro que esta prestado.
        /// </summary>
        public class EliminarLibroPrestadoException : Exception 
        {
            public EliminarLibroPrestadoException(Libro libro)
            {
                this.Libro = libro;
            }

            public Libro Libro { set; get; }
        }

        /// <summary>
        /// Devuelve una lista de todos los libros ordenados por el campo id_libro de manera Ascendente
        /// </summary>
        /// <returns>Lista de libros</returns>
        public List<Libro> GetAll()
        {
            List<Libro> libros = new List<Libro>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Libro ORDER BY id_libro ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Libro libro = new Libro
                        {
                            Id = Convert.ToInt32(row["id_libro"]),
                            CodigoIdentificacionUnico = Convert.ToString(row["codigo_identificacion_unico"]),
                            Titulo = Convert.ToString(row["titulo"]),
                            ISBN = Convert.ToString(row["isbn"]),
                            IdLector = (row["id_lector"]) == DBNull.Value ? null : (int?)(row["id_lector"])
                        };
                        libros.Add(libro);
                    }
                }
            }
            return libros;
        }

        /// <summary>
        /// Retorna los libros que estan en prestamo.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEnPrestamo()
        {
            DataTable table = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = @"SELECT 
                                            Libro.id_libro,
                                            Libro.codigo_identificacion_unico,
                                            Libro.titulo,
                                            Libro.isbn,
                                            Lector.Apellido
                                          FROM Libro 
                                          INNER JOIN Lector ON Lector.id_lector = Libro.id_lector
                                          ORDER BY id_libro ASC";
                
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);                    
                }
            }
            return table;
        }

        /// <summary>
        /// Cantidad de libros agrupados por lector.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEnPrestamoAgrupado()
        {
            DataTable table = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = @"SELECT 
                                            Lector.id_lector,
                                            Lector.apellido,
                                            Lector.dni,
                                            Count(Libro.id_libro) as [Cantidad de libros en prestamo]
                                          FROM Libro 
                                          RIGHT JOIN Lector ON Lector.id_lector = Libro.id_lector
                                          GROUP BY 
                                                    Lector.id_lector,
                                                    Lector.apellido,
                                                    Lector.dni
                                          ORDER BY Lector.apellido ASC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
            }
            return table;
        }

        /// <summary>
        /// Retorna los lectores a los que no se les prestaron libros.
        /// </summary>
        /// <returns></returns>
        public DataTable GetLectoresSinLibros()
        {
            DataTable table = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                const string sqlQuery = @"SELECT *                                             
                                          FROM Lector
                                          WHERE 
                                               Lector.id_lector NOT IN  
                                                        (
                                                            SELECT id_lector FROM Libro 
                                                            WHERE id_lector IS NOT null                          
                                                        )                                          
                                          ORDER BY Lector.apellido ASC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
            }
            return table;
        }
    }
}
