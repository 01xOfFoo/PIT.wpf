using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business.Entities;
using PIT.Business.Filter;

namespace PIT.Tests.Business
{
    [TestClass]
    public class IssueFilterTests
    {
        private IssueFilter _filter;

        [TestInitialize]
        public void SetUp()
        {
            _filter = new IssueFilter();
        }

        [TestMethod]
        public void AddStatusToFilter()
        {
            _filter.AddFilter(IssueStatus.Assigned);
        }

        [TestMethod]
        public void RemoveStatusFromFilter()
        {
            _filter.RemoveFilter(IssueStatus.Assigned);
        }

        [TestMethod]
        public void AbsorbsIssueIfStatusIsNotInList()
        {
            _filter.AddFilter(IssueStatus.Assigned);

            var absorb = _filter.Absorb(new Issue(){Status = IssueStatus.Done});
            Assert.AreEqual(true, absorb);
        }

        [TestMethod]
        public void AppliesFilterOntoList()
        {
            _filter.AddFilter(IssueStatus.Assigned);

            var issues = new List<Issue>
            {
                new Issue() {Status = IssueStatus.Assigned},
                new Issue() {Status = IssueStatus.Done}
            };

            var filteredIssues = _filter.Filter(issues);
            Assert.AreEqual(1, filteredIssues.Count());
        }
    }
}