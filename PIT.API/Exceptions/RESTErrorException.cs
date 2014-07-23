using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace PIT.API.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class RestErrorException : Exception
    {
        public RestErrorException(HttpResponseMessage responseMessage) 
            : base(CreateMessage(responseMessage))
        {
        }

        private static string CreateMessage(HttpResponseMessage responseMessage)
        {
            return string.Format("Error receiving request: Statuscode {0}", responseMessage.StatusCode);
        }
    }
}