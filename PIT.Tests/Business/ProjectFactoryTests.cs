using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business;

namespace PIT.Tests.Business
{
    [TestClass]
    public class ProjectFactoryTests
    {
        [TestMethod]
        public void CanCreateNewProject()
        {
            var projectFactory = new ProjectFactory();
            var project = projectFactory.CreateProject();
            Assert.IsNotNull(project);
        }
    }
}