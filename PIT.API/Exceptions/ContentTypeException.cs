using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace PIT.API.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ContentTypeException : Exception
    {
        public ContentTypeException(HttpStatusCode statusCode, string mimeType, string expectedMimeType)
            : base(CreateMessage(statusCode, mimeType, expectedMimeType))
        {
            
        }

        private static string CreateMessage(HttpStatusCode statusCode, string mimeType, string expectedMimeType)
        {
            return string.Format("Mime type '{0}' does not match the expected '{1}' (status code {2}.", 
                    mimeType, expectedMimeType, statusCode);
        }
    }
}