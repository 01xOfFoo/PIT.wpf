using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Project;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.Tests.WPF.Commands.Project
{
    [TestClass]
    public class AddProjectCommandTests
    {
        private AddProjectCommand _command;
        private Mock<IProjectBusiness> _projectBusiness;
        private Mock<IProjectEditViewModel> _projectEditViewModelMock;
        private Mock<ProjectSelection> _projectSelection;
        private Mock<IViewModelFactory<ProjectViewModel, PIT.Business.Entities.Project>> _projectViewModelFactory;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {
            _windowManager = new Mock<IWindowManager>();
            _projectBusiness = new Mock<IProjectBusiness>();
            _projectEditViewModelMock = new Mock<IProjectEditViewModel>();

            _projectViewModelFactory = new Mock<IViewModelFactory<ProjectViewModel, PIT.Business.Entities.Project>>();
            _projectViewModelFactory.Setup(f => f.CreateViewModel(It.IsAny<PIT.Business.Entities.Project>()))
                .Returns(new ProjectViewModel
                {
                    Project = new PIT.Business.Entities.Project()
                });

            _projectSelection = new Mock<ProjectSelection>();

            _command = new AddProjectCommand(_windowManager.Object, _projectBusiness.Object, _projectSelection.Object,
                _projectEditViewModelMock.Object,
                _projectViewModelFactory.Object);
        }

        [TestMethod]
        public void CreatesNewViewModelUsingTheFactory()
        {
            _command.Execute(null);
            _projectViewModelFactory.Verify(f => f.CreateViewModel(It.IsAny<PIT.Business.Entities.Project>()));
        }

        [TestMethod]
        public void DisplaysEditView()
        {
            _command.Execute(null);
            _windowManager.Verify(w => w.ShowDialog(It.IsAny<object>(), null, null));
        }

        [TestMethod]
        public void DelegatesSaveActionIfDialogResultIsTrue()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(true);

            _command.Execute(null);
            _projectBusiness.Verify(b => b.Create(It.IsAny<PIT.Business.Entities.Project>()));
            Assert.AreEqual(1, _projectSelection.Object.Projects.Count);
        }

        [TestMethod]
        public void ResetsOldProjectIfDialogResultIsFalse()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(false);
            _command.Execute(null);
            Assert.IsNull(_projectSelection.Object.SelectedProject);
        }
    }
}