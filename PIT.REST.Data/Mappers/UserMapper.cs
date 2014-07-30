using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Mappers
{
    public class UserMapper : BaseMapper<User>
    {
        protected UserMapper()
        {
            ToTable("Users");

            Property(u => u.Short).IsRequired();
            Property(u => u.Short).HasMaxLength(2);

            Property(u => u.Name).IsRequired();
        }
    }
}