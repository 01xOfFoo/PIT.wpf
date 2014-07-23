using System;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.API.Exceptions;
using PIT.API.HTTP;
using PIT.API.HTTP.Contracts;

namespace PIT.Tests.API.HTTP
{
    [TestClass]
    public class ResponseMessageValidatorTests
    {
        private IResponseMessageValidator _validator;

        private HttpResponseMessage CreateResponseMessage(HttpStatusCode code)
        {
            var response = new HttpResponseMessage(code)
            {
                Content = new StringContent("")
            };
            return response;
        }

        private HttpResponseMessage CreateFalseResponseMessage()
        {
            return CreateResponseMessage(HttpStatusCode.BadRequest);
        }

        private HttpResponseMessage CreateSucceedingResponseMessage()
        {
            return CreateResponseMessage(HttpStatusCode.Accepted);
        }

        [TestInitialize]
        public void SetUp()
        {
            _validator = new ResponseMessageValidator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FailsIfResponseMessageIsNull()
        {
            _validator.Ensure(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ContentTypeException))]
        public void FailsIfResponseContentTypeIsEmpty()
        {
            var response = CreateSucceedingResponseMessage();
            response.Content.Headers.ContentType = null;
            _validator.Ensure(response);
        }

        [TestMethod]
        [ExpectedException(typeof(ContentTypeException))]
        public void FailsIfResponseContentMediaTypeIsNotJson()
        {
            var response = CreateSucceedingResponseMessage();
            _validator.Ensure(response);
        }

        [TestMethod]
        [ExpectedException(typeof(RestErrorException))]
        public void FailsIfResponseStatusIsNotSucceeded()
        {
            var response = CreateFalseResponseMessage();
            _validator.Ensure(response);
        }

        [TestMethod]
        public void EnsuresResponse()
        {
            var response = CreateSucceedingResponseMessage();
            response.Content.Headers.ContentType.MediaType = "application/json";
            _validator.Ensure(response);
        }
    }
}
