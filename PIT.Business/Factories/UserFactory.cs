using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Factories.Contracts;

namespace PIT.Business.Factories
{
    [Export(typeof(IUserFactory))]
    public class UserFactory : IUserFactory
    {
        public User CreateUser()
        {
            return new User();
        }
    }
}