using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public static class ConnectionString
    {
        /// <summary>
        /// Lee la cadena de conexión a la base de datos codificada en base64.
        /// </summary>
        /// <returns></returns>
        public static string ReadEncode()
        {
            /***
             * Lee la cadena de conexión a la base de datos codificada en base64, 
             * ya que de este modo está escrita en el archivo de configuración.
             ***/
            string connectionStringCodificado = ConfigurationManager.ConnectionStrings["cnnString"].ToString();

            return connectionStringCodificado;
        }

        public static string ReadDecode()
        {
            /***
             * Lee la cadena de conexión a la base de datos codificada en base64, 
             * ya que de este modo está escrita en el archivo de configuración.
             ***/
            string connectionStringCodificado = ConnectionString.ReadEncode();

            /***
             * Decodifica la cadena de conexión codificada, para obtener la 
             * cadena que se utilizara efectivamente para acceder a la base de datos.
             ***/
            string connectionString = Codificador.Decode(connectionStringCodificado);

            return connectionString;
        }      
    }
}
