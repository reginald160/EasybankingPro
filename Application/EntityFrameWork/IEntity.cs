using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EntityFrameWork
{
    /// <summary>
    /// holds standard properties  like to have on any database-peristed object,
    /// creation and modification dates, and who created or last modified it.
    /// </summary>
    public interface IEntity : IModifiableEntity
    {
        object Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        byte[] Version { get; set; }
    }

    /// <summary>
    ///  holds a single property, Id, which is generically typed. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
