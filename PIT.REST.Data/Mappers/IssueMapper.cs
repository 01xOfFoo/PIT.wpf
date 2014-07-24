using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Mappers
{
    public class IssueMapper : BaseMapper<Issue>
    {
        public IssueMapper()
        {
            ToTable("Issues");

            Property(i => i.Description).IsOptional();
            Property(i => i.Description).HasMaxLength(1000);

            Property(i => i.Short).IsRequired();
            Property(i => i.Short).HasMaxLength(10);

            Property(i => i.Status).IsRequired();
            HasRequired(i => i.Project).WithMany().Map(p => p.MapKey("ProjectId")).WillCascadeOnDelete();
        }
    }
}