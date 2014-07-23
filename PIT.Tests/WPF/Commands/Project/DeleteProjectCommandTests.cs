using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Project;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Commands.Project
{
    [TestClass]
    public class DeleteProjectCommandTests
    {
        private DeleteProjectCommand _command;
        private Mock<IProjectBusiness> _projectBusiness;
        private Mock<IProjectsModel> _projectModel;

        [TestInitialize]
        public void SetUp()
        {
            var project = new ProjectViewModel();
            var projects = new ObservableCollection<ProjectViewModel> {project};

            _projectModel = new Mock<IProjectsModel>();
            _projectModel.SetupProperty(m => m.Projects, projects);
            _projectModel.SetupProperty(m => m.SelectedProject, project);

            _projectBusiness = new Mock<IProjectBusiness>();

            _command = new DeleteProjectCommand(_projectModel.Object, _projectBusiness.Object);
            _command.Execute(null);
        }

        [TestMethod]
        public void DelegatesRemoveSelectedProject()
        {
            _projectBusiness.Verify(b => b.Delete(It.IsAny<PIT.Business.Entities.Project>()));
        }

        [TestMethod]
        public void RemovesProjectFromInternalList()
        {
            _projectModel.VerifyGet(m => m.Projects);
            Assert.AreEqual(0, _projectModel.Object.Projects.Count);
        }
    }
}