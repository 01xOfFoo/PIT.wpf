using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Filter.Contracts;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;

namespace PIT.Tests.Models.Issues
{
    [TestClass]
    public class IssueCollectionTests
    {
        private IssueCollection _collection;
        private Mock<IViewModelFactory<IssueViewModel, Issue>> _factory;
        private Mock<IIssueFilter> _filter;
        private Mock<IIssueBusiness> _service;

        private static void PublishIssueEvent(Issue issue)
        {
            Events.Current.Publish(issue);
        }

        [TestInitialize]
        public void SetUp()
        {
            _filter = new Mock<IIssueFilter>();
            _service = new Mock<IIssueBusiness>();
            _factory = new Mock<IViewModelFactory<IssueViewModel, Issue>>();
            _collection = new IssueCollection(_filter.Object, _service.Object, _factory.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            _collection.Dispose();
        }

        [TestMethod]
        public void LoadsIssues()
        {
            var issues = new List<Issue>
            {
                new Issue(),
                new Issue()
            };

            _service.Setup(s => s.GetIssuesOfProject(It.IsAny<int>())).Returns(issues);
            _filter.Setup(f => f.Match(It.IsAny<Issue>())).Returns(true);
            _collection.Load(new Project());
            _service.Verify(s => s.GetIssuesOfProject(It.IsAny<int>()));
            Assert.AreEqual(2, _collection.Items.Count);
        }

        [TestMethod]
        public void AddsIssueIfNotInList()
        {
            _filter.Setup(f => f.Match(It.IsAny<Issue>())).Returns(true);
            PublishIssueEvent(new Issue());
            Assert.AreEqual(1, _collection.Items.Count);
        }

        [TestMethod]
        public void RemovesIssueIfOutOfFilterRange()
        {
            var issue = new Issue();
            _collection.Items.Add(new IssueViewModel(issue));

            _filter.Setup(f => f.Match(It.IsAny<Issue>())).Returns(false);
            PublishIssueEvent(issue);
            Assert.AreEqual(0, _collection.Items.Count);
        }
    }
}