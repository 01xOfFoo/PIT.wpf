using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Factories.Contracts;
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
            ProjectViewModel viewModel = _projectViewModelFactory.CreateViewModel(It.IsAny<Project>());
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(viewModel.Project);
            _projectFactory.Verify(f => f.CreateProject());
        }
    }
}