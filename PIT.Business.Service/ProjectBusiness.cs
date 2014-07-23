using System.ComponentModel.Composition;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    [Export(typeof(IProjectBusiness))]
    public class ProjectBusiness : Business<Project>, IProjectBusiness
    {
        [ImportingConstructor]
        public ProjectBusiness(IClientProvider provider) 
            : base(provider.ProjectClient)
        {
        }
    }
}