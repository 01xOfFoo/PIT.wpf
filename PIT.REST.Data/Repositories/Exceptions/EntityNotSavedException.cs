using System;

namespace PIT.REST.Data.Repositories.Exceptions
{
    public class EntityNotSavedException : Exception
    {
        public EntityNotSavedException(string relation, Exception ex) 
            : base(string.Format("Could not save {0}", relation), ex)
        {
        }
    }
}