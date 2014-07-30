using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Loaders;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Models.Issues
{
    [TestClass]
    public class IssuesLoaderTests
    {
        private Mock<IIssueBusiness> _issueBusiness;
        private IssueSelection _issueSelection;
        private List<Issue> _issues;
        private IssuesLoader _loader;
        private ProjectSelection _projectSelection;
        private Mock<IViewModelFactory<IssueViewModel, Issue>> _viewModelFactory;

        [TestInitialize]
        public void SetUp()
        {
            _projectSelection = new ProjectSelection
            {
                SelectedProject = new ProjectViewModel {Project = new Project {Id = 1}}
            };

            _issueSelection = new IssueSelection();

            _viewModelFactory = new Mock<IViewModelFactory<IssueViewModel, Issue>>();
            _viewModelFactory.Setup(f => f.CreateViewModel(It.IsAny<Issue>()))
                .Returns((Issue i) => new IssueViewModel {Issue = i});

            _issues = new List<Issue>();

            _issueBusiness = new Mock<IIssueBusiness>();
            _issueBusiness.Setup(b => b.GetAll()).Returns(_issues);
            _issueBusiness.Setup(b => b.GetIssuesOfProject(It.IsAny<int>())).Returns(_issues);

            _loader = new IssuesLoader(_issueBusiness.Object, _viewModelFactory.Object,
                _projectSelection, _issueSelection);
        }

        [TestMethod]
        public void LoadsIssuesOfSelectedProject()
        {
            _loader.Load();
            _issueBusiness.Verify(b => b.GetIssuesOfProject(It.Is<int>(i => i == 1)));
        }

        [TestMethod]
        public void SetsSelectedProjectAsParent()
        {
            _issues.Add(new Issue {Id = 1});
            _loader.Load();
            Assert.AreEqual(1, _issueSelection.Issues[0].Id);
        }
    }
}