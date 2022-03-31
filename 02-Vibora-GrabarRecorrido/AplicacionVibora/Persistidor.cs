using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AplicacionVibora
{
    /// <summary>
    /// Responsable de manejar la lectura y escritura del archivo de texto.
    /// </summary>
    public static class Persistidor
    {
        /// <summary>
        /// Graba las coordenadas x,y de la cabeza de 
        /// la víbora en una base de datos en disco.
        /// </summary>
        /// <param name="vibora"></param>
        public static void GrabarCoordenadas(Vibora vibora)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery =
                    @"INSERT INTO Coordenada 
                                (X, Y) 
                      VALUES 
                                (@X, @Y)";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@X", vibora.XCabeza);
                    cmd.Parameters.AddWithValue("@Y", vibora.YCabeza);

                    int count = cmd.ExecuteNonQuery();
                }
            }            
        }

        /// <summary>
        /// Carga el camino recorrido por la víbora desde una base de datos en disco.
        /// </summary>
        /// <returns></returns>
        public static List<Asterisco> LeerCaminoGrabado()
        {
            List<Asterisco> camino = new List<Asterisco>();
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {              
                const string sqlQuery = "SELECT * FROM Coordenada";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {
                    DataTable table = new DataTable();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Asterisco asterisco = new Asterisco
                        {
                            X = (int)(row["X"]),
                            Y = (int)(row["Y"]),
                            Color = ConsoleColor.Green                            
                        };
                        camino.Add(asterisco);
                    }
                }
            }
            return camino;
        }

        /// <summary>
        /// Elimina el camino grabado en una base de datos.
        /// </summary>
        public static void EliminarCaminoGrabado()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
            using (OleDbConnection cnx = new OleDbConnection(connectionString))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Coordenada";
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, cnx))
                {                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
