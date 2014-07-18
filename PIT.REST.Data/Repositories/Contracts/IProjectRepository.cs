using System.Linq;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Repositories.Contracts
{
    public interface IProjectRepository
    {
        IQueryable<Project> GetAllProjects();
        Project GetProject(int projectId);
        Project Create(Project project);
        Project Update(Project project);
        Project Delete(int projectId);
    }
}