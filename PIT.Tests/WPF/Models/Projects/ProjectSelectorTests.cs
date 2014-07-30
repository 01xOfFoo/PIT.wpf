using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business.Entities.Events.Projects;
using PIT.Core;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Models.Projects
{
    [TestClass]
    public class ProjectSelectorTests
    {
        private ProjectSelection _projectSelection;
        private ProjectSelector _selector;

        [TestInitialize]
        public void SetUp()
        {
            _projectSelection = new ProjectSelection();
            _selector = new ProjectSelector(_projectSelection);
        }

        [TestMethod]
        public void SelectsLastProjectIfProjectIsRemoved()
        {
            _projectSelection.Projects.Add(new ProjectViewModel());

            Events.Current.Publish(new ProjectDeleted(null));
            Assert.AreEqual(_projectSelection.Projects.Last(), _projectSelection.SelectedProject);
        }

        [TestMethod]
        public void SetsDefaultProjectIfListIsEmpty()
        {
            var project = new ProjectViewModel();
            _projectSelection.Projects.Add(project);
            _projectSelection.Projects.Remove(project);
            Assert.IsNull(_projectSelection.SelectedProject);
        }

        [TestMethod]
        public void UnSubscribesFromProjectModelForListOfProjectsChanges()
        {
            _selector.Dispose();
        }

        [TestMethod]
        public void SelectsFirstProjectIfProjectWasRemoved()
        {
            _projectSelection.Projects.Add(new ProjectViewModel());
            _projectSelection.Projects.Add(new ProjectViewModel());

            _projectSelection.SelectedProject = _projectSelection.Projects[1];
            Events.Current.Publish(new ProjectDeleted(null));

            Assert.AreSame(_projectSelection.SelectedProject, _projectSelection.Projects[0]);
        }
    }
}