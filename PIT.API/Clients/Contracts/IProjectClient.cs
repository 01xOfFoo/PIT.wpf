using System.Collections.Generic;
using PIT.Business.Entities;

namespace PIT.API.Clients.Contracts
{
    public interface IProjectClient
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(int projectId);
        void CreateProject(Project project);
        void DeleteProject(Project project);
        void Update(Project project);
    }
}