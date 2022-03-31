using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class Lector : IEntity
    {
        public int? Id { get; set; }
        public int DNI { get; set; }
        public string Apellido { get; set; }
    }
}
