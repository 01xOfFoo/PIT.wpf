using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;

namespace PIT.Tests.API.HTTP
{
    [TestClass]
    public class PITHttpClientTests
    {
        private HttpClient _http;
        private IHttpClient _httpClient;

        [TestInitialize]
        public void SetUp()
        {
            _http = new HttpClient();
            _httpClient = new PITHttpClient(_http);
        }

        [TestMethod]
        public void AppliesJsonMediaTypeHeader()
        {
            Assert.AreEqual("application/json", _http.DefaultRequestHeaders.Accept.First().MediaType);
        }
    }
}
