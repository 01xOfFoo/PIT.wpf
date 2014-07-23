using System.Net.Http;

namespace PIT.API.HTTP.Contracts
{
    public interface IResponseMessageValidator
    {
        void Ensure(HttpResponseMessage responseMessage);
    }
}