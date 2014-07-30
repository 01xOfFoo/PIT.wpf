using System.ComponentModel.Composition;
using PIT.API.Clients;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.API.HTTP.Contracts;

namespace PIT.API
{
    [Export(typeof(IClientProvider))]
    public class ClientProvider : IClientProvider
    {
        private readonly IEnvironment _environment;
        private readonly IHttpClient _httpClient;
        private readonly IResponseMessageValidator _responseMessageValidator;

        private IIssueClient _issueClient;
        private IProjectClient _projectClient;
        private IUserClient _userClient;

        [ImportingConstructor]
        public ClientProvider(IEnvironment environment, IHttpClient httpClient,
            IResponseMessageValidator responseMessageValidator)
        {
            _environment = environment;
            _httpClient = httpClient;
            _responseMessageValidator = responseMessageValidator;
        }

        public IProjectClient ProjectClient
        {
            get
            {
                IProjectClient client = _projectClient;
                if (client == null)
                {
                    client = new ProjectRestClient(_httpClient, _responseMessageValidator)
                    {
                        ServerAdress = _environment.ServerAdress
                    };

                    _projectClient = client;
                }
                return client;
            }
        }

        public IIssueClient IssueClient
        {
            get
            {
                IIssueClient client = _issueClient;
                if (client == null)
                {
                    client = new IssueRestClient(_httpClient, _responseMessageValidator)
                    {
                        ServerAdress = _environment.ServerAdress
                    };
                    _issueClient = client;
                }
                return client;
            }
        }

        public IUserClient UserClient
        {
            get
            {
                IUserClient client = _userClient;
                if (client == null)
                {
                    client = new UserRestClient(_httpClient, _responseMessageValidator)
                    {
                        ServerAdress = _environment.ServerAdress
                    };
                    _userClient = client;
                }
                return client;
            }
        }
    }
}