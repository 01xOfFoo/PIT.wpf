using System.Data.Entity;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Context.Seeders
{
    public class PITDataSeeder : DropCreateDatabaseAlways<PITContext>
    {
        private PITContext _context;

        protected override void Seed(PITContext context)
        {
            _context = context;
            base.Seed(context);

            FillProjectsDatabase();
            FillIssueDatabase();
        }

        private void FillProjectsDatabase()
        {
            for (int i = 1; i <= 3; i++)
                _context.Projects.Add(BuildProject(i));

            _context.SaveChanges();
        }

        private Project BuildProject(int count)
        {
            return new Project
            {
                Description = string.Format("Awesome Project {0}", count),
                Short = string.Format("PROJECT {0}", count)
            };
        }

        private void FillIssueDatabase()
        {
            for (int i = 1; i <= 3; i++)
                _context.Issues.Add(BuildIssue(1, i));

            for (int i = 1; i <= 4; i++)
                _context.Issues.Add(BuildIssue(2, i));

            for (int i = 1; i <= 2; i++)
                _context.Issues.Add(BuildIssue(3, i));

            _context.SaveChanges();
        }

        private Issue BuildIssue(int projectId, int count)
        {
            var issue = new Issue();
            issue.Short = string.Format("I{0}", count);
            issue.Description = string.Format("Issue #{0}", count);
            issue.Project = _context.Projects.Find(projectId);

            return issue;
        }
    }
}