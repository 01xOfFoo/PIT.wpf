using System;

namespace PIT.REST.Models.Factories.Exceptions
{
    public class ModelNotParseableException : Exception
    {
        public ModelNotParseableException(string message) : base(string.Format("Error while parsing {0} request", message))
        {
        }
    }
}