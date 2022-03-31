using System;
namespace DataAccessLayer
{
    /// <summary>
    /// Obliga a todas la entidades a implementar una propiedad Id, 
    /// que la identifica inequívocamente.
    /// </summary>
    interface IEntity
    {
        int? Id { get; set; }
    }
}
