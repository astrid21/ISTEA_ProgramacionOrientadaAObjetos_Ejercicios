using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppErrores
{
    /// <summary>
    /// Representacion en objetos, no hay mas latas de tomates.
    /// </summary>
    public class SinLataDeTomatesException : Exception
    {
        public SinLataDeTomatesException(int cantLatasFaltantes) : base()
        {
            //Enviar un correo 
        }

        public SinLataDeTomatesException() : base()
        {
        }

        public SinLataDeTomatesException(string message) : base(message)
        {
            this.TotalDeLatasEnStock = 10;
        }

        public int TotalDeLatasEnStock { set; get; }

        public SinLataDeTomatesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SinLataDeTomatesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
