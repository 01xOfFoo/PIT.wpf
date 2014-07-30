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
        private ProjectSelection _projectSelection;

        [TestInitialize]
        public void SetUp()
        {
            var project = new ProjectViewModel();
            var projects = new ObservableCollection<ProjectViewModel> {project};

            _projectSelection = new ProjectSelection();
            foreach (ProjectViewModel p in projects)
            {
                _projectSelection.Projects.Add(p);
            }
            _projectSelection.SelectedProject = project;

            _projectBusiness = new Mock<IProjectBusiness>();

            _command = new DeleteProjectCommand(_projectSelection, _projectBusiness.Object);
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
            Assert.AreEqual(0, _projectSelection.Projects.Count);
        }
    }
}