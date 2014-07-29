using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PIT.API.HTTP.Contracts
{
    public interface IHttpClientProxy
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
        HttpRequestHeaders DefaultRequestHeaders { get; }
    }
}