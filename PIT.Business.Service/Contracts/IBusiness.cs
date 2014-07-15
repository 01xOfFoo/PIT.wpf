using System.Collections.Generic;

namespace PIT.Business.Service.Contracts
{
    public interface IBusiness<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
