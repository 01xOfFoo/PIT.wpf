using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Models.Projects
{
    [TestClass]
    public class ProjectSelectorTests
    {
        private ProjectSelection _projectModel;
        private ProjectSelector _selector;

        [TestInitialize]
        public void SetUp()
        {
            _projectModel = new ProjectSelection();
            _selector = new ProjectSelector(_projectModel);
        }

        [TestMethod]
        public void SelectsNewlyAddedProject()
        {
            var newProject = new ProjectViewModel();
            _projectModel.Projects.Add(newProject);

            Assert.AreEqual(newProject, _projectModel.SelectedProject);
        }

        [TestMethod]
        public void SelectsFirstProjectIfProjectIsRemoved()
        {
            _projectModel.Projects.Add(new ProjectViewModel());
            _projectModel.Projects.Add(new ProjectViewModel());
            _projectModel.Projects.Add(new ProjectViewModel());

            _projectModel.SelectedProject = _projectModel.Projects.Last();
            _projectModel.Projects.Remove(_projectModel.Projects.Last());
            Assert.AreEqual(_projectModel.Projects[0], _projectModel.SelectedProject);
        }

        [TestMethod]
        public void SetsDefaultProjectIfListIsEmpty()
        {
            var project = new ProjectViewModel();
            _projectModel.Projects.Add(project);
            _projectModel.Projects.Remove(project);
            Assert.IsNull(_projectModel.SelectedProject);
        }

        [TestMethod]
        public void UnSubscribesFromProjectModelForListOfProjectsChanges()
        {
            _selector.Dispose();
            _selector = null;
        }
    }
}