using PIT.API.HTTP;

namespace PIT.API.Clients
{
    public class BaseClient
    {
        protected readonly IHttpClient HttpClient;

        public string ServerAdress { get; set; }

        protected BaseClient(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}