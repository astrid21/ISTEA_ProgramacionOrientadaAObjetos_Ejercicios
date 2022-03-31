﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryADOPersister
{
    public interface IPersistible
    {
        /// <summary>
        /// Persiste un Producto.
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        void Save(Producto producto);

        /// <summary>
        /// Elimina un Producto por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Remove(int id);

        /// <summary>
        /// Elimina un Producto por su representación en objetos.
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        void Remove(Producto producto);

        /// <summary>
        /// Retorna el Producto por el ID especificado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Producto Load(int id);

        /// <summary>
        /// Retorna los Productos que cumplen con la condición especificada, Conteniendo parte del nombre.
        /// </summary>
        /// <param name="partOfDescription"></param>
        /// <returns></returns>
        List<Producto> Find(string partOfDescription);

        /// <summary>
        /// Pasa los valores de los campos del registro cuyo id es idA, al registro cuyo id es idB y viceversa.
        /// </summary>
        /// <param name="idA">primary key A</param>
        /// <param name="idB">primary key B</param>
        void Enroque(int idA, int idB);
    }
}