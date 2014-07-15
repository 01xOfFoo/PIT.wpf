using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Mappers
{
    public class BaseMapper<T> : EntityTypeConfiguration<T> where T : Entity
    {
        protected BaseMapper()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Id).IsRequired();

            Property(t => t.CreatedAt).IsOptional();
        }
 
    }
}
