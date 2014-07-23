using System.ComponentModel.Composition;
using PIT.Business.Contracts;
using PIT.Business.Entities;

namespace PIT.Business
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