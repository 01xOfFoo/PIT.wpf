using PIT.API.Clients;
using PIT.API.Clients.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Contracts
{
    public interface IClientProvider
    {
        IProjectClient ProjectClient { get; }
        IIssueClient IssueClient { get; }
    }
}