using System.Collections.Generic;

namespace PIT.API.Clients
{
    public interface IClient<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}