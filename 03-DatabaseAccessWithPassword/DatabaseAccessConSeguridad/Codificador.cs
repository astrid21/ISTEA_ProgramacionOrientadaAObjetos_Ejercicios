using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Puede utilizar el sitio http://base64encode.net/ para codificar y decodificar a y desde base64.
    /// </remarks>
    public static class Codificador
    {
        /// <summary>
        /// Codifica un texto a Base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Decodifica un texto escrito en codigo Base64.
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
