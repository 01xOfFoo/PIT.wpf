using PIT.REST.Data.Entities;

namespace PIT.REST.Models.Factories
{
    public interface IModelFactory
    {
        ProjectModel CreateProject(Project project);
        IssueModel CreateIssue(Issue issue);
        Project ParseProject(ProjectModel projectModel);
        Issue ParseIssue(IssueModel issueModel);
    }
}