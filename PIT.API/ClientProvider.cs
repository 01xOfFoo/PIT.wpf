using System.ComponentModel.Composition;
using PIT.API.Clients;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.API.HTTP;
using PIT.API.Validators;
using PIT.API.Validators.Contracts;
using PIT.Business.Entities;

namespace PIT.API
{
    [Export(typeof(IClientProvider))]
    public class ClientProvider : IClientProvider
    {
        private readonly IHttpClient _httpClient;
        private readonly IEnvironment _environment;
        private readonly IResponseMessageValidator _responseMessageValidator;

        private IProjectClient _projectClient;
        private IIssueClient _issueClient;

        [ImportingConstructor]
        public ClientProvider(IEnvironment environment, IHttpClient httpClient, IResponseMessageValidator responseMessageValidator)
        {
            _environment = environment;
            _httpClient = httpClient;
            _responseMessageValidator = responseMessageValidator;
        }

        public IProjectClient ProjectClient
        {
            get
            {
                var client = _projectClient;
                if (client == null)
                {
                    client = new ProjectClient(_httpClient, _responseMessageValidator)
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
                var client = _issueClient;
                if (client == null)
                {
                    client = new IssueClient(_httpClient, _responseMessageValidator)
                    {
                        ServerAdress = _environment.ServerAdress
                    };
                    _issueClient = client;
                }
                return client;
            }
        }
    }
}