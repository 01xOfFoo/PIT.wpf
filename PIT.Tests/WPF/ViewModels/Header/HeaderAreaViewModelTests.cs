using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Header;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.ViewModels.Header
{
    [TestClass]
    public class HeaderAreaViewModelTests 
    {
        private Mock<ProjectSelection> _projectsModel;
        private HeaderAreaViewModel _viewModel;

        [TestInitialize]
        public void SetUp()
        {
            _projectsModel = new Mock<ProjectSelection>();
            _viewModel = new HeaderAreaViewModel(_projectsModel.Object);
        }

        [TestMethod]
        public void SubscribesToProjectChanges()
        {
            Assert.IsTrue(_projectsModel.Object.HasProjectChangedSubscriber());
        }

        [TestMethod]
        public void UnsubscribesFromProjectChangedHandler()
        {
            _viewModel.Dispose();
            _viewModel = null;
            Assert.IsFalse(_projectsModel.Object.HasProjectChangedSubscriber());
        }

        [TestMethod]
        public void SelectedProjectNameIsRaised()
        {
            _projectsModel.Object.SelectedProject = new ProjectViewModel();
        }
    }
}
