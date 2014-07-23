using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Contracts;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.ViewModels.Projects
{
    [TestClass]
    public class ProjectViewModelFactoryTests
    {
        private Mock<IProjectFactory> _projectFactory;
        private ProjectViewModelFactory _projectViewModelFactory;
        private Project _usedProject;

        [TestInitialize]
        public void SetUp()
        {
            _usedProject = new Project();

            _projectFactory = new Mock<IProjectFactory>();
            _projectFactory.Setup(f => f.CreateProject()).Returns(_usedProject);

            _projectViewModelFactory = new ProjectViewModelFactory(_projectFactory.Object);
        }

        [TestMethod]
        public void CreateNewProjectViewModelUsingProjectFactory()
        {
            var viewModel = _projectViewModelFactory.CreateProjectViewModel();
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(viewModel.Project);
            _projectFactory.Verify(f => f.CreateProject());
        }
    }
}