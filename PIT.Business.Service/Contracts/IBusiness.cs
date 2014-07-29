using System.Collections.Generic;

namespace PIT.Business.Service.Contracts
{
    public interface IBusiness<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}