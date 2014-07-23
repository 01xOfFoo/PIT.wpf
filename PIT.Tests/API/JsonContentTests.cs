using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.API;

namespace PIT.Tests.API
{
    [TestClass]
    public class JsonContentTests
    {
        [TestMethod]
        public void CreatesContentWithJsonAsMediaType()
        {
            var content = new JsonContent("");
            Assert.AreEqual("application/json", content.Headers.ContentType.MediaType);
        }

        [TestMethod]
        public void CreatesContentWithUTF8Encoding()
        {
            var content = new JsonContent("");
            Assert.AreEqual("utf-8", content.Headers.ContentType.CharSet);
        }
    }
}
