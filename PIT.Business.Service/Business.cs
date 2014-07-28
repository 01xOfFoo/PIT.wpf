using System.Collections.Generic;
using PIT.API.Clients;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    public class Business<T> : IBusiness<T> where T : Entity
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

        public virtual T Create(T entity)
        {
            var response = Client.Create(entity);
            entity.Id = response.Id;
            return response;
        }

        public virtual T Update(T entity)
        {
            return Client.Update(entity);
        }

        public void Delete(T entity)
        {
            Client.Delete(entity);
        }
    }
}