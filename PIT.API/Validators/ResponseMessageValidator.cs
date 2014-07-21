using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using PIT.API.Exceptions;
using PIT.API.Validators.Contracts;

namespace PIT.API.Validators
{
    [Export(typeof(IResponseMessageValidator))]
    public class ResponseMessageValidator : IResponseMessageValidator
    {
        public void Ensure(HttpResponseMessage responseMessage)
        {
            if (responseMessage == null)
                throw new ArgumentNullException("responseMessage");

            EnsureResponseSuccess(responseMessage);
            EnsureResponseType(responseMessage);
        }

        private void EnsureResponseType(HttpResponseMessage responseMessage)
        {
            if (responseMessage.Content.Headers.ContentType == null)
                throw new ContentTypeException(responseMessage.StatusCode, string.Empty, "application/json");

            var responseType = responseMessage.Content.Headers.ContentType.MediaType;
            if (!responseType.Equals("application/json"))
                throw new ContentTypeException(responseMessage.StatusCode, responseType, "application/json");
        }

        private void EnsureResponseSuccess(HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
                throw new RestErrorException(responseMessage);
        }
    }
}