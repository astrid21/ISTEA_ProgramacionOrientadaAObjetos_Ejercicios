using System;
namespace DataAccessLayer
{
    /// <summary>
    /// Es implementada por todos los persistidores, 
    /// para lograr una funcionalidad común, 
    /// básicamente el CRUD (Create, Read, Update and Delete).
    /// </summary>
    /// <typeparam name="I"></typeparam>
    interface ILibroPersistidor<I>
    {
        void Delete(int idLibro);
        System.Collections.Generic.List<I> GetAll();
        I GetByid(int idLibro);
        void Save(I libro);
    }
}
