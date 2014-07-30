using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Factories.Contracts;

namespace PIT.Business.Factories
{
    [Export(typeof(IIssueFactory))]
    public class IssueFactory : IIssueFactory
    {
        public Issue CreateIssue()
        {
            return new Issue();
        }
    }
}