using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.WPF.Commands.Project;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.Tests.WPF.Commands.Project
{
    [TestClass]
    public class EditProjectCommandTests
    {
        private EditProjectCommand _command;
        private Mock<IProjectEditViewModel> _projectEditViewModel;
        private Mock<ProjectSelection> _projectModel;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {
            _projectModel = new Mock<ProjectSelection>();
            _windowManager = new Mock<IWindowManager>();
            _projectEditViewModel = new Mock<IProjectEditViewModel>();

            _command = new EditProjectCommand(_projectModel.Object, _windowManager.Object, _projectEditViewModel.Object);
            _command.Execute(null);
        }

        [TestMethod]
        public void ActivatesSelectedProjectViewModel()
        {
            _projectEditViewModel.Verify(e => e.ActivateProject(It.IsAny<ProjectViewModel>()));
        }

        [TestMethod]
        public void DisplaysEditView()
        {
            _windowManager.Verify(w => w.ShowDialog(It.IsAny<object>(), null, null));
        }
    }
}