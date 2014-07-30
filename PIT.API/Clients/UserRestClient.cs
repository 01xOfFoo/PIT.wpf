using PIT.API.Clients.Contracts;
using PIT.API.HTTP.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class UserRestClient : RestClient<User>, IUserClient
    {
        public UserRestClient(IHttpClient httpClient, IResponseMessageValidator validator) 
            : base(httpClient, validator)
        {
            RessourceUri = "api/users";
        }
    }
}