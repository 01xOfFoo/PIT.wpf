using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Mappers
{
    public class ProjectMapper : BaseMapper<Project>
    {
        public ProjectMapper()
        {
            ToTable("Projects");

            Property(p => p.Short).HasMaxLength(15);
            Property(p => p.Short).IsOptional();

            Property(p => p.Description).IsOptional();
            Property(p => p.Description).HasMaxLength(1000);
        }
    }
}