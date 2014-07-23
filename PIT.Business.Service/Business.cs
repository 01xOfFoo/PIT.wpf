using System.Collections.Generic;
using PIT.API.Clients;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    public class Business<T> : IBusiness<T> where T : class
    {
        protected readonly IClient<T> Client;

        protected Business(IClient<T> client)
        {
            Client = client;
        }

        public T GetById(int id)
        {
            return Client.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Client.GetAll();
        }

        public void Create(T entity)
        {
            Client.Create(entity);
        }

        public void Update(T entity)
        {
            Client.Update(entity);
        }

        public void Delete(T entity)
        {
            Client.Delete(entity);
        }
    }
}