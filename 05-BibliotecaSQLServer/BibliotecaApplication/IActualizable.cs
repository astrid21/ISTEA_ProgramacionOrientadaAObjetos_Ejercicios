using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormApplication
{
    /// <summary>
    /// Obliga a las clases de consulta a implementarla para conseguir el refresco automático de todas ellas.
    /// </summary>
    public interface IActualizable
    {
        void ActualizarConsulta();
    }
}
