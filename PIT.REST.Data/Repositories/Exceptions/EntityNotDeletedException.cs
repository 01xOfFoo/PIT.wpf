using System;

namespace PIT.REST.Data.Repositories.Exceptions
{
    public class EntityNotDeletedException : Exception
    {
        public EntityNotDeletedException(string relation, Exception exception)
            : base(string.Format("Could not delete {0}", relation), exception)
        {
            
        }
    }
}