using System.Linq;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Filter.Contracts;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Issue;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.Tests.WPF.Commands.Issue
{
    [TestClass]
    public class EditIssueCommandTests
    {
        private EditIssueCommand _command;
        private Mock<IIssueBusiness> _issueBusiness;
        private Mock<IIssueEditViewModel> _issueEditViewModel;
        private IssueSelection _issueSelection;
        private Mock<IWindowManager> _windowManager;
        private Mock<IIssueFilter> _issueFilter;

        [TestInitialize]
        public void SetUp()
        {
            _windowManager = new Mock<IWindowManager>();
            _issueBusiness = new Mock<IIssueBusiness>();
            _issueEditViewModel = new Mock<IIssueEditViewModel>();

            _issueSelection = new IssueSelection();

            var issue = new IssueViewModel
            {
                Issue = new PIT.Business.Entities.Issue
                {
                    Short = "short"
                }
            };
            _issueSelection.Issues.Add(issue);
            _issueSelection.SelectedIssue = issue;

            _issueFilter = new Mock<IIssueFilter>();

            _command = new EditIssueCommand(_windowManager.Object, _issueBusiness.Object, _issueFilter.Object, _issueSelection,
                _issueEditViewModel.Object);
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
            IssueViewModel issue = _issueSelection.SelectedIssue;
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

        [TestMethod]
        public void RemovesIssueFromListIfFilterAbsorbs()
        {
            _windowManager.Setup(w => w.ShowDialog(It.IsAny<object>(), null, null)).Returns(true).Callback(() => _issueSelection.SelectedIssue.Status = IssueStatus.Done);
            _issueFilter.Setup(f => f.Absorb(It.IsAny<PIT.Business.Entities.Issue>())).Returns(true);
            _command.Execute(null);
            Assert.IsFalse(_issueSelection.Issues.Any());
        }
    }
}