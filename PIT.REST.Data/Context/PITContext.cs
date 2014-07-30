using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
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

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Project> Projects { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Issue> Issues { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectMapper());
            modelBuilder.Configurations.Add(new IssueMapper());

            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            try
            {
                SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}