using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Filter;
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
        private Mock<IIssueBusiness> _business;
        private Mock<IIssueFilter> _issueFilter;
        private IssueSelection _issueSelection;
        private IssuesLoader _loader;
        private ProjectSelection _projectSelection;
        private Mock<IViewModelFactory<IssueViewModel, Issue>> _viewModelFactory;

        [TestInitialize]
        public void SetUp()
        {
            _projectSelection = new ProjectSelection();
            _issueSelection = new IssueSelection();
            _viewModelFactory = new Mock<IViewModelFactory<IssueViewModel, Issue>>();
            _issueFilter = new Mock<IIssueFilter>();
            _business = new Mock<IIssueBusiness>();
            _business.Setup(b => b.GetAll()).Returns(new List<Issue>());

            _loader = new IssuesLoader(_business.Object, _viewModelFactory.Object, _projectSelection, _issueSelection,
                _issueFilter.Object);
        }

        [TestMethod]
        public void LoadsIssuesOfSelectedProject()
        {
            _projectSelection.SelectedProject = new ProjectViewModel {Project = new Project {Id = 1}};
            _loader.Load();
            _business.Verify(b => b.GetIssuesOfProject(It.Is<int>(i => i == 1)));
        }
    }
}