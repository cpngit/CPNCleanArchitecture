using CPN.Model;
using System.Collections.Generic;

namespace CPN.Application
{

    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        T Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
