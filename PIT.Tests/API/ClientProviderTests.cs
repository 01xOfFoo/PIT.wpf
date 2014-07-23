using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API;
using PIT.API.Contracts;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;

namespace PIT.Tests.API
{
    [TestClass]
    public class ClientProviderTests
    {
        private ClientProvider _provider;

        [TestInitialize]
        public void ClientProviderTest()
        {
            var environment = new Mock<IEnvironment>();
            var httpClient = new Mock<IHttpClient>();
            var validator = new Mock<IResponseMessageValidator>();
            _provider = new ClientProvider(environment.Object, httpClient.Object, validator.Object);
        }

        [TestMethod]
        public void CanProvideClients()
        {
            var projectClient = _provider.ProjectClient;
            var issueClient = _provider.IssueClient;
            Assert.IsNotNull(projectClient);
            Assert.IsNotNull(issueClient);
        }

        [TestMethod]
        public void UsesSingletonPatternForClients()
        {
            var projectClient = _provider.ProjectClient;
            var projectClient2 = _provider.ProjectClient;

            var issueClient = _provider.IssueClient;
            var issueClient2 = _provider.IssueClient;

            Assert.AreEqual(projectClient, projectClient2);
            Assert.AreEqual(issueClient, issueClient2);
        }
    }
}
