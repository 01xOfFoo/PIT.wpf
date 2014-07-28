using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Service.Contracts;
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
        private Mock<IProjectBusiness> _projectBusiness;
        private Mock<IProjectEditViewModel> _projectEditViewModel;
        private Mock<ProjectSelection> _projectSelection;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {
            _projectSelection = new Mock<ProjectSelection>();
            var project = new ProjectViewModel
            {
                Project = new PIT.Business.Entities.Project(),
                Short = "short"
            };
            _projectSelection.Object.SelectedProject = project;


            _windowManager = new Mock<IWindowManager>();
            _projectBusiness = new Mock<IProjectBusiness>();
            _projectEditViewModel = new Mock<IProjectEditViewModel>();

            _command = new EditProjectCommand(_windowManager.Object, _projectBusiness.Object, _projectSelection.Object,
                _projectEditViewModel.Object);
        }

        [TestMethod]
        public void DisplaysEditView()
        {
            _command.Execute(null);
            _windowManager.Verify(w => w.ShowDialog(It.IsAny<object>(), null, null));
        }

        [TestMethod]
        public void RestoresViewModelsIfDialogWasAborted()
        {
            ProjectViewModel project = _projectSelection.Object.SelectedProject;
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Callback(() => project.Short = "");
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(false);
            _command.Execute(null);

            Assert.AreEqual("short", project.Short);
        }

        [TestMethod]
        public void DelegatesUpdateIfDialogResultIsTrue()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(true);
            _command.Execute(null);
            _projectBusiness.Verify(b => b.Update(It.IsAny<PIT.Business.Entities.Project>()));
        }
    }
}