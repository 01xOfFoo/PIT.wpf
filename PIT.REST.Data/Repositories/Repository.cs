using System.Data.Entity;
using System.Linq;
using PIT.REST.Data.Context;
using PIT.REST.Data.Repositories.Contracts;

namespace PIT.REST.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PITContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PITContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.Save();

            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.Save();

            return entity;
        }

        public T Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.Save();

            return entity;
        }
    }
}