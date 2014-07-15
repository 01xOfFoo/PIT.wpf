using System.ComponentModel.Composition;
using PIT.API.Clients;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.API.HTTP;

namespace PIT.API
{
    [Export(typeof(IClientProvider))]
    public class ClientProvider : IClientProvider
    {
        private readonly IHttpClient _httpClient;
        private readonly IEnvironment _environment;

        private IProjectClient _projectClient;
        private IIssueClient _issueClient;

        [ImportingConstructor]
        public ClientProvider(IEnvironment environment, IHttpClient httpClient)
        {
            _environment = environment;
            _httpClient = httpClient;
        }

        public IProjectClient ProjectClient
        {
            get
            {
                var client = _projectClient;
                if (client == null)
                {
                    client = new ProjectClient(_httpClient)
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
                    client = new IssueClient(_httpClient)
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