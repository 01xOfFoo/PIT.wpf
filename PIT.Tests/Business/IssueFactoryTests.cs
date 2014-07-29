using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business;
using PIT.Business.Entities;

namespace PIT.Tests.Business
{
    [TestClass]
    public class IssueFactoryTests
    {
        [TestMethod]
        public void CanCreateNewIssue()
        {
            var projectFactory = new IssueFactory();
            Issue project = projectFactory.CreateIssue();
            Assert.IsNotNull(project);
        }
    }
}