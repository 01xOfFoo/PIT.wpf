using System.Collections.Generic;

namespace PIT.Business.Service.Contracts
{
    public interface IBusiness<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
