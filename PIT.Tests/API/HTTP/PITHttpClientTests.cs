using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;

namespace PIT.Tests.API.HTTP
{
    [TestClass]
    public class PITHttpClientTests
    {
        private Mock<IHttpClientProxy> _http;
        private IHttpClient _httpClient;

        [TestInitialize]
        public void SetUp()
        {
            _http = new Mock<IHttpClientProxy>();
            _httpClient = new PITHttpClient(_http.Object);
        }

        [TestMethod]
        public void CanCreateInstanceWithoutParameter()
        {
            _httpClient = new PITHttpClient();
        }

        [TestMethod]
        public void AppliesJsonMediaTypeHeader()
        {
            var http = new HttpClientProxy();
            _httpClient = new PITHttpClient(http);
            Assert.AreEqual("application/json", http.DefaultRequestHeaders.Accept.First().MediaType);
        }

        [TestMethod]
        public void CanInvokeGetRequest()
        {
            Task<HttpResponseMessage> task = GetResponseTask();
            _http.Setup(h => h.GetAsync(It.IsAny<string>())).Returns(task);

            _httpClient.Get(It.IsAny<string>());

            _http.Verify(h => h.GetAsync(It.IsAny<string>()));
        }

        [TestMethod]
        public void CanInvokePostRequest()
        {
            Task<HttpResponseMessage> task = GetResponseTask();
            _http.Setup(h => h.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).Returns(task);

            _httpClient.Post(It.IsAny<string>(), It.IsAny<HttpContent>());

            _http.Verify(h => h.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()));
        }

        [TestMethod]
        public void CanInvokePutRequest()
        {
            Task<HttpResponseMessage> task = GetResponseTask();
            _http.Setup(h => h.PutAsync(It.IsAny<string>(), It.IsAny<HttpContent>())).Returns(task);

            _httpClient.Put(It.IsAny<string>(), It.IsAny<HttpContent>());

            _http.Verify(h => h.PutAsync(It.IsAny<string>(), It.IsAny<HttpContent>()));
        }

        [TestMethod]
        public void CanInvokeDeleteRequest()
        {
            Task<HttpResponseMessage> task = GetResponseTask();
            _http.Setup(h => h.DeleteAsync(It.IsAny<string>())).Returns(task);

            _httpClient.Delete(It.IsAny<string>());

            _http.Verify(h => h.DeleteAsync(It.IsAny<string>()));
        }

        private static Task<HttpResponseMessage> GetResponseTask()
        {
            var task = new Task<HttpResponseMessage>(It.IsAny<HttpResponseMessage>);
            task.Start();
            return task;
        }
    }
}