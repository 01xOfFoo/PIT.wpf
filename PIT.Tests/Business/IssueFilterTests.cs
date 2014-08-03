using System.Collections.Generic;
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
        public void MatchesFilter()
        {
            _filter.AddFilter(IssueStatus.Done);
            var match = _filter.Match(new Issue(){Status = IssueStatus.Done});
            Assert.AreEqual(true, match);
        }

        [TestMethod]
        public void DoesntMatchFilterIfStatusIsNotInList()
        {
            _filter.AddFilter(IssueStatus.Done);
            var match = _filter.Match(new Issue() { Status = IssueStatus.Assigned });
            Assert.AreEqual(false, match);
        }
    }
}