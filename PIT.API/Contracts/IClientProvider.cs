using PIT.API.Clients.Contracts;

namespace PIT.API.Contracts
{
    public interface IClientProvider
    {
        IProjectClient ProjectClient { get; }
        IIssueClient IssueClient { get; }
    }
}