using System;
using System.Data.Entity;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Context.Seeders
{
    public class PITDataSeeder : DropCreateDatabaseAlways<PITContext>
    {
        private PITContext _context;
        private Random _rnd;

        public PITDataSeeder()
        {
            _rnd = new Random();
        }

        protected override void Seed(PITContext context)
        {
            _context = context;
            base.Seed(context);

            FillProjectsDatabase();
            FillUserDatabase();
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

        private void FillUserDatabase()
        {
            _context.Users.Add(new User
            {
                Short = "aa",
                Name = "Anton Anders"
            });
            _context.Users.Add(new User
            {
                Short = "bb",
                Name = "Berta Böße"
            });
            _context.Users.Add(new User
            {
                Short = "cc",
                Name = "Carmen Corinte"
            });

            _context.Save();
        }

        private void FillIssueDatabase()
        {
           
            for (int i = 1; i <= 10; i++)
                _context.Issues.Add(BuildIssue(i));

            _context.Save();
        }

        private Issue BuildIssue(int count)
        {
            var issue = new Issue();
            issue.Project = GetRandomProject();

            issue.Short = string.Format("{0}-{1}", issue.Project.Id, count);
            issue.Description = string.Format("Issue description #{0}", count);

            int number = _rnd.Next(0, (int)IssueStatus.ReOpened + 1);
            issue.Status = (IssueStatus) number;

            issue.Developer = GetRandomUser();
            issue.Tester = GetRandomUser();


            return issue;
        }

        private Project GetRandomProject()
        {
            var id = _rnd.Next(1, 4);
            return _context.Projects.Find(id);
        }

        private User GetRandomUser()
        {
            var id = _rnd.Next(1, 4);
            return _context.Users.Find(id);
        }
    }
}