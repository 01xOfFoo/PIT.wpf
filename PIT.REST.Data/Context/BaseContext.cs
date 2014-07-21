using System.Configuration;
using System.Data.Entity;

namespace PIT.REST.Data.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base(ConfigurationManager.ConnectionStrings["PITDB"].Name)
        {
            
        }
    }
}