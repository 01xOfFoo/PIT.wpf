using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.Business.Service;

namespace PIT.Tests.Business.Service
{
    [TestClass]
    public class IssueBusinessTests
    {
        Mock<IIssueClient> _issueClient;
        private IssueBusiness _business;

        [TestInitialize]
        public void SetUp()
        {
            _issueClient = new Mock<IIssueClient>();

            var clientProvider = new Mock<IClientProvider>();
            clientProvider.SetupGet(p => p.IssueClient).Returns(_issueClient.Object);

            _business = new IssueBusiness(clientProvider.Object);
        }

        [TestMethod]
        public void ReturnsIssuesOfGivenProject()
        {
            _business.GetIssuesOfProject(It.IsAny<int>());
            _issueClient.Verify(ic => ic.GetIssuesOfProject(It.IsAny<int>()));
        }
    }
}
