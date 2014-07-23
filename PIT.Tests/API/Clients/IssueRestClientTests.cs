using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API.Clients;
using PIT.API.Clients.Contracts;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;

namespace PIT.Tests.API.Clients
{
    [TestClass]
    public class IssueRestClientTests
    {
        private IIssueClient _client;
        private Mock<IResponseMessageValidator> _validator;
        private Mock<IHttpClient> _httpClient;

        [TestInitialize]
        public void SetUp()
        {
            _validator = new Mock<IResponseMessageValidator>();
            _httpClient = new Mock<IHttpClient>();

            _client = new IssueRestClient(_httpClient.Object, _validator.Object);
        }

        [TestMethod]
        public void BuildHttpGetForIssuesOfProject()
        {
            _httpClient.Setup(c => c.Get(It.IsAny<string>())).Returns(new HttpResponseMessage());

            _client.GetIssuesOfProject(0);

            _httpClient.Verify(c => c.Get(It.IsAny<string>()));
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }
    }
}
