using System.Net.Http;
using PIT.API.HTTP.Contracts;

namespace PIT.API.HTTP
{
    public class HttpClientProxy : HttpClient, IHttpClientProxy
    {
        public HttpClientProxy() : base()
        {
        }
    }
}