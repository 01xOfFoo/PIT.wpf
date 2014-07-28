using System;
using PIT.REST.Data.Entities;
using PIT.REST.Models.Factories.Exceptions;

namespace PIT.REST.Models.Factories
{
    public class ModelFactory : IModelFactory
    {
        public virtual ProjectModel CreateProject(Project project)
        {
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
            return new IssueModel
            {
                Id = issue.Id,
                CreatedAt = issue.CreatedAt,
                Description = issue.Description,
                Status = issue.Status,
                ProjectId = issue.ProjectId
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
                return new Issue()
                {
                    Id = issueModel.Id,
                    Short = issueModel.Short,
                    CreatedAt = issueModel.CreatedAt,
                    Status = issueModel.Status,
                    Description = issueModel.Description,
                    ProjectId = issueModel.Project.Id
                };
            }
            catch (Exception)
            {
                throw new ModelNotParseableException("issue");
            }
        }
    }
}