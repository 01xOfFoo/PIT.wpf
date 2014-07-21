using System.Net.Http;

namespace PIT.API.Validators.Contracts
{
    public interface IResponseMessageValidator
    {
        void Ensure(HttpResponseMessage responseMessage);
    }
}