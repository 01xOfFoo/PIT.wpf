using System.Collections.Generic;

namespace PIT.Business.Entities
{
    public class Workspace
    {
        private IList<User> _users;
        public IList<User> Users 
        {
            get { return _users; }
            private set { _users = value; }
        }

        public Workspace()
        {
            _users = new List<User>();
        }
    }
}