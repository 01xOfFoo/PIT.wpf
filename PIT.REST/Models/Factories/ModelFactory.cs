using System;
using PIT.REST.Data.Entities;
using PIT.REST.Models.Factories.Exceptions;

namespace PIT.REST.Models.Factories
{
    public class ModelFactory : IModelFactory
    {
        public virtual ProjectModel CreateProject(Project project)
        {
            if (project == null)
                return null;

            return new ProjectModel
            {
                Id = project.Id,
                CreatedAt = project.CreatedAt,
                Description = project.Description,
                Short = project.Short
            };
        }

        public virtual IssueModel CreateIssue(Issue issue)
        {
            if (issue == null)
                return null;

            return new IssueModel
            {
                Id = issue.Id,
                CreatedAt = issue.CreatedAt,
                Description = issue.Description,
                Status = issue.Status,
                Project = CreateProject(issue.Project),
                Developer = CreateUser(issue.Developer),
                Tester = CreateUser(issue.Tester)
            };
        }

        public virtual UserModel CreateUser(User user)
        {
            if (user == null)
                return null;

            return new UserModel
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                Short = user.Short,
                Name = user.Name
            };
        }

        public virtual Project ParseProject(ProjectModel projectModel)
        {
            try
            {
                if (projectModel != null)
                {
                    var project = new Project();
                    project.Id = projectModel.Id;
                    project.CreatedAt = projectModel.CreatedAt;
                    project.Description = projectModel.Description;
                    project.Short = projectModel.Short;
                    return project;
                }
            }
            catch (Exception)
            {
                throw new ModelNotParseableException("project");
            }

            return null;
        }

        public Issue ParseIssue(IssueModel issueModel)
        {
            try
            {
                return new Issue
                {
                    Id = issueModel.Id,
                    Short = issueModel.Short,
                    CreatedAt = issueModel.CreatedAt,
                    Status = issueModel.Status,
                    Description = issueModel.Description,
                    ProjectId = issueModel.Project.Id,
                    DeveloperId = GetEntityId(issueModel.Developer),
                    TesterId = GetEntityId(issueModel.Tester)
                };
            }
            catch (Exception)
            {
                throw new ModelNotParseableException("issue");
            }
        }

        public User ParseUser(UserModel userModel)
        {
            try
            {
                return new User
                {
                    Id = userModel.Id,
                    CreatedAt = userModel.CreatedAt,
                    Short = userModel.Short,
                    Name = userModel.Name
                };
            }
            catch (Exception)
            {
                throw new ModelNotParseableException("user");
            }
        }

        private int? GetEntityId(BaseModel model)
        {
            return model != null && model.Id > 0 ? (int?) model.Id : null;
        }
    }
}