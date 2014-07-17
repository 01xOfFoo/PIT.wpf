using System.Net.Http;
using PIT.API.HTTP;
using PIT.API.Validators.Contracts;

namespace PIT.API.Clients
{
    public class BaseClient
    {
        private readonly IResponseMessageValidator _validator;

        protected readonly IHttpClient HttpClient;

        public string ServerAdress { get; set; }

        protected BaseClient(IHttpClient httpClient, IResponseMessageValidator validator)
        {
            HttpClient = httpClient;
            _validator = validator;
        }

        protected void ValidateResponse(HttpResponseMessage responseMessage)
        {
            _validator.Ensure(responseMessage);
        }
    }
}