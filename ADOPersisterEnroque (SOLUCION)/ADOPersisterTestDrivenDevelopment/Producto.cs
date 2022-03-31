using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryADOPersister
{
    public class Producto
    {
        public int? Id { set; get; }
        public string Descripcion { set; get; }
        public string Marca { set; get; }
        public double Precio { set; get; }
    }
}
