using System.Data.Entity;
using PIT.REST.Data.Context.Seeders;
using PIT.REST.Data.Entities;
using PIT.REST.Data.Mappers;

namespace PIT.REST.Data.Context
{
#if DEBUG
    public class PITContext : DbContext
    {
        public PITContext() : base("PIT")
#else
    public class ProjectContext : BaseContext
    {
        public ProjectContext() : BaseContext
#endif
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new PITDataSeeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectMapper());
            modelBuilder.Configurations.Add(new IssueMapper());

            base.OnModelCreating(modelBuilder);
        }

// ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Project> Projects { get; set; }
// ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Issue> Issues { get; set; }
    }
}