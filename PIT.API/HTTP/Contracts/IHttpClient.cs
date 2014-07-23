using System.Net.Http;

namespace PIT.API.HTTP.Contracts
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string uri);
        HttpResponseMessage Put(string uri, HttpContent content);
        HttpResponseMessage Post(string uri, HttpContent content);
        HttpResponseMessage Delete(string uri);
    }
}