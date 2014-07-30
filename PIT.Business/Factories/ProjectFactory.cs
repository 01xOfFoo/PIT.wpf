using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Factories.Contracts;

namespace PIT.Business.Factories
{
    [Export(typeof(IProjectFactory))]
    public class ProjectFactory : IProjectFactory
    {
        public Project CreateProject()
        {
            return new Project();
        }
    }
}