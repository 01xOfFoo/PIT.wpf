using System;
using System.Data.Entity;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Context.Seeders
{
    public class PITDataSeeder : DropCreateDatabaseAlways<PITContext>
    {
        private PITContext _context;
        private Random _rnd;

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

            _context.Save();
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
            _rnd = new Random();
            
            for (int i = 1; i <= 3; i++)
                _context.Issues.Add(BuildIssue(1, i));

            for (int i = 1; i <= 4; i++)
                _context.Issues.Add(BuildIssue(2, i));

            for (int i = 1; i <= 2; i++)
                _context.Issues.Add(BuildIssue(3, i));

            _context.Save();
        }

        private Issue BuildIssue(int projectId, int count)
        {
            var issue = new Issue();
            issue.Short = string.Format("{0}-{1}", projectId, count);
            issue.Description = string.Format("Issue description #{0}", count);

            int number = _rnd.Next(0, (int)IssueStatus.ReOpened + 1);
            issue.Status = (IssueStatus) number;

            issue.Project = _context.Projects.Find(projectId);

            return issue;
        }
    }
}