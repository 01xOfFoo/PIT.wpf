using System.ComponentModel.Composition;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    [Export(typeof(IUserBusiness))]
    public class UserBusiness : Business<User>, IUserBusiness
    {
        [ImportingConstructor]
        public UserBusiness(IClientProvider provider)
            : base(provider.UserClient)
        {
        }
    }
}