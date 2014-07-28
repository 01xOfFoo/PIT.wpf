using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Issue;
using PIT.WPF.Commands.Project;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.Tests.WPF.Commands.Project
{
    [TestClass]
    public class EditIssueCommandTests
    {
        private EditIssueCommand _command;
        private Mock<IIssueBusiness> _issueBusiness;
        private Mock<IIssueEditViewModel> _issueEditViewModel;
        private Mock<IssueSelection> _issueSelection;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {

            _windowManager = new Mock<IWindowManager>();
            _issueBusiness = new Mock<IIssueBusiness>();
            _issueEditViewModel = new Mock<IIssueEditViewModel>();

            _issueSelection = new Mock<IssueSelection>();
            _issueSelection.Object.SelectedIssue = new IssueViewModel()
            {
                Issue = new PIT.Business.Entities.Issue()
                {
                    Short = "short"
                }
            };

            _command = new EditIssueCommand(_windowManager.Object, _issueBusiness.Object, _issueSelection.Object, _issueEditViewModel.Object);
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
            IssueViewModel issue = _issueSelection.Object.SelectedIssue;
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Callback(() => issue.Short = "");
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(false);
            _command.Execute(null);

            Assert.AreEqual("short", issue.Short);
        }

        [TestMethod]
        public void DelegatesUpdateIfDialogResultIsTrue()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(true);
            _command.Execute(null);
            _issueBusiness.Verify(b => b.Update(It.IsAny<PIT.Business.Entities.Issue>()));
        }
    }
}