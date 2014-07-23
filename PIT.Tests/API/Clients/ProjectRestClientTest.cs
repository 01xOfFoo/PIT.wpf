using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API.Clients;
using PIT.API.HTTP.Contracts;
using PIT.Business.Entities;

namespace PIT.Tests.API.Clients
{
    [TestClass]
    public class ProjectRestClientTest
    {
        private Mock<IResponseMessageValidator> _validator;
        private Mock<IHttpClient> _httpClient;
        private ProjectRestClient _client;

        [TestInitialize]
        public void SetUp()
        {
            _httpClient = new Mock<IHttpClient>();
            _validator = new Mock<IResponseMessageValidator>();

            _client = new ProjectRestClient(_httpClient.Object, _validator.Object);
        }

        [TestMethod]
        public void BuildGetAllHttpGetAndValidateResponse()
        {
            _httpClient.Setup(c => c.Get(It.IsAny<string>())).Returns(new HttpResponseMessage());

            _client.GetAll();
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }

        [TestMethod]
        public void BuildGetByIdHttpGetAndValidateResponse()
        {
            _httpClient.Setup(c => c.Get(It.IsAny<string>())).Returns(new HttpResponseMessage());

            _client.GetById(0);
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }

        [TestMethod]
        public void BuildHttpPostAndValidatesResponse()
        {
            _httpClient.Setup(c => c.Post(It.IsAny<string>(), It.IsAny<HttpContent>())).Returns(new HttpResponseMessage());
            _client.Create(It.IsAny<Project>());
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }

        [TestMethod]
        public void BuildHttpPutAndValidatesResponse()
        {
            _httpClient.Setup(c => c.Put(It.IsAny<string>(), It.IsAny<HttpContent>())).Returns(new HttpResponseMessage());
            var project = new Project {Id = 0};
            _client.Update(project);
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }

        [TestMethod]
        public void BuildHttpDeleteAndValidatesResponse()
        {
            _httpClient.Setup(c => c.Delete(It.IsAny<string>())).Returns(new HttpResponseMessage());
            var project = new Project { Id = 0 };
            _client.Delete(project);
            _validator.Verify(v => v.Ensure(It.IsAny<HttpResponseMessage>()));
        }
    }
}
