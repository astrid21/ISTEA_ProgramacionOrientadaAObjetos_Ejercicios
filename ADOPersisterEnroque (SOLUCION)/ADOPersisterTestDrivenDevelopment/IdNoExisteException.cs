using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryADOPersister
{
    public class IdNoExisteException : Exception
    {
        public IdNoExisteException()
        {
        }

        public IdNoExisteException(string message) : base(message)
        {
        }
    }
}
