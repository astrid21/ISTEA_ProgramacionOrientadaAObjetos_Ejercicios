using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2OOP2021
{
    public interface IPersistible
    {
        /// <summary>
        /// Inserta una lista de "Clientes" en la base de datos.
        /// </summary>
        /// <remarks>
        /// En caso de ser exitosa la inserción de un Cliente, 
        /// el ítem correspondiente de la lista de errores retornada debe ser null,
        /// indicando de esta manera el existo en la inserción, caso contrario 
        /// el ítem correspondiente debe establecerse a la Excepción indicativa del 
        /// error ocurrido durante la inserción.
        /// 
        /// Si la lista de clientes es nula, el método debe retornar una lista, 
        /// no nula, con cero ítems.
        /// 
        /// Este método es responsable de establecer el valor del campo ID, 
        /// clave primaria de la entidad Cliente.
        /// </remarks>
        /// <param name="clientes">
        /// Lista de Clientes a insertar.
        /// </param>
        /// <returns>
        /// Lista de errores (exceptions) ocurridos en cada inserción.
        /// La cantidad de ítems de la lista de errores es igual a la
        /// cantidad de clientes que el método intenta insertar.
        /// </returns>
        List<Exception> Insert(List<Cliente> clientes);

        /// <summary>
        /// Elimina un Cliente por su id.
        /// </summary>
        /// <exception cref="ClienteNoEncontradoException">
        /// En caso de no ser encontrado en la base de datos el id del Cliente a eliminar, 
        /// el método debe lanzar la excepción indicada.
        /// Indicando en la propia Exception.Message el ID del cliente que no se encontró.
        /// </exception>
        /// <exception cref="ClienteConDeudaException">
        /// No se puede eliminar un cliente que posea deuda, en su lugar debe lanzarse 
        /// una excepción indicando como parte de la propiedad 
        /// Exception.Message el valor de la deuda.        
        /// </exception>
        /// <param name="id"></param>
        /// <returns></returns>
        void Remove(int id);

        /// <summary>
        /// Elimina un Cliente por su representación en objetos.
        /// </summary>
        /// <exception cref="ClienteNoEncontradoException">
        /// En caso de no ser encontrado en la base de datos, id del Cliente a eliminar, 
        /// el método debe lanzar la excepción.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// En caso que el Cliente pasado como parametro fuese null, se debe lanlar la excepción.
        /// </exception>
        /// <exception cref="ClienteIdIsNullException">
        /// En caso que el id del Cliente pasado como parametro fuese null, se debe lanlar la excepción.
        /// </exception>
        /// <exception cref="ClienteConDeudaException">
        /// No se puede eliminar un cliente que posea deuda, en su lugar debe lanzarse una 
        /// excepción indicando como parte de la propiedad Exception.Message el valor de la deuda.
        /// </exception> 
        /// <param name="Cliente"></param>
        /// <returns></returns>
        void Remove(Cliente cliente);

        /// <summary>
        /// Retorna el Cliente por el ID especificado.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ClienteNoEncontradoException">
        /// En caso de no ser encontrado en la base de datos el id del Cliente, 
        /// el método debe lanzar la excepción.
        /// Indicando como parte de la propiedad Exception.Message el valor del id.
        /// </exception>
        /// <returns></returns>
        Cliente Get(int id);

        /// <summary>
        /// Retorna los Clientes que cumplen con la condición especificada, conteniendo parte del apellido.
        /// </summary>
        /// <param name="partOfApellido"></param>
        /// <exception cref="ClienteNoEncontradoException">
        /// En caso de no existir clientes que cumplen con lo requerido, 
        /// el método debe lanzar la excepción.
        /// Indicando como parte de la propiedad Exception.Message el valor buscado.
        /// </exception>
        /// <returns></returns>
        List<Cliente> SearchByApellido(string partOfApellido);

        /// <summary>
        /// Otorga un nuevo valor de ID a los clientes (registros) existentes, 
        /// estableciéndolo al siguiente.
        /// Observe el siguiente ejemplo de antes y después de la remuneración:
        /// </summary>
        /// <example>
        /// Antes:
        ///        ID   Apellido    DNI     Deuda
        ///        33	Sadosky	    127	    10
        ///        34	Favaloro	128	    111
        ///        35	Sabato		129	    0
        ///
        /// Después:
        ///         ID  Apellido    DNI     Deuda
        ///         36	Sadosky	    127	    10
        ///         37	Favaloro	128	    111
        ///         38	Sabato		129	    0
        /// </example>
        void RenumerarPorID();
    }
}