using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Issue;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Commands.Issue
{
    [TestClass]
    public class AddIssueCommandTests
    {
        private AddIssueCommand _command;
        private Mock<IIssueBusiness> _issueBusiness;
        private Mock<IIssueEditViewModel> _issueEditViewModelMock;
        private Mock<IssueSelection> _issueSelection;
        private Mock<IIssueViewModelFactory> _issueViewModelFactory;
        private Mock<ProjectSelection> _projectSelection;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {
            _windowManager = new Mock<IWindowManager>();
            _issueBusiness = new Mock<IIssueBusiness>();
            _issueEditViewModelMock = new Mock<IIssueEditViewModel>();

            _issueViewModelFactory = new Mock<IIssueViewModelFactory>();
            _issueViewModelFactory.Setup(f => f.CreateIssueViewModel())
                .Returns(new IssueViewModel
                {
                    Issue = new PIT.Business.Entities.Issue()
                });

            _issueSelection = new Mock<IssueSelection>();

            _projectSelection = new Mock<ProjectSelection>();
            _projectSelection.Object.SelectedProject = new ProjectViewModel
            {
                Project = new PIT.Business.Entities.Project()
            };

            _command = new AddIssueCommand(_windowManager.Object, _issueBusiness.Object, _issueSelection.Object,
                _projectSelection.Object, _issueEditViewModelMock.Object, _issueViewModelFactory.Object);
        }

        [TestMethod]
        public void CreatesNewViewModelUsingTheFactory()
        {
            _command.Execute(null);
            _issueViewModelFactory.Verify(f => f.CreateIssueViewModel());
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
            _issueBusiness.Verify(b => b.Create(It.IsAny<PIT.Business.Entities.Issue>()));
            Assert.AreEqual(1, _issueSelection.Object.Issues.Count);
        }

        [TestMethod]
        public void ResetsOldProjectIfDialogResultIsFalse()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(false);
            _command.Execute(null);
            Assert.IsNull(_issueSelection.Object.SelectedIssue);
        }
    }
}