using System.Linq;

namespace PIT.REST.Data.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(int id);
    }
}