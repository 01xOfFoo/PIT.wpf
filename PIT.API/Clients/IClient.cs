using System.Collections.Generic;

namespace PIT.API.Clients
{
    public interface IClient<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}