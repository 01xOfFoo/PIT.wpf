using System.Collections.Generic;
using System.Net.Http;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class RestClient<T> : IClient<T> where T : Entity
    {
        private readonly IResponseMessageValidator _validator;

        protected readonly IHttpClient HttpClient;

        public string ServerAdress { get; set; }
        protected string RessourceUri { get; set; }

        protected RestClient(IHttpClient httpClient, IResponseMessageValidator validator)
        {
            HttpClient = httpClient;
            _validator = validator;
        }

        protected void ValidateResponse(HttpResponseMessage responseMessage)
        {
            _validator.Ensure(responseMessage);
        }

        public IEnumerable<T> GetAll()
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}", ServerAdress, RessourceUri));
            ValidateResponse(responseMessage);
            return JsonConverter<T>.CreateList(responseMessage);
        }

        public T GetById(int id)
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, id));
            ValidateResponse(responseMessage);

            return JsonConverter<T>.Create(responseMessage);
        }

        public T Create(T entity)
        {
            var content = JsonConverter<T>.Create(entity);
            var responseMessage = HttpClient.Post(string.Format("{0}/{1}", ServerAdress, RessourceUri), content);
            ValidateResponse(responseMessage);

            return JsonConverter<T>.Create(responseMessage);
        }

        public T Update(T entity)
        {
            var content = JsonConverter<T>.Create(entity);
            var responseMessage = HttpClient.Put(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, entity.Id), content);
            ValidateResponse(responseMessage);

            return JsonConverter<T>.Create(responseMessage);
        }

        public void Delete(T entity)
        {
            var responseMessage = HttpClient.Delete(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, entity.Id));
            ValidateResponse(responseMessage);
        }
    }
}