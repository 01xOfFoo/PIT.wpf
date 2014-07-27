using System.ComponentModel.Composition;
using PIT.Business.Contracts;
using PIT.Business.Entities;

namespace PIT.Business
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