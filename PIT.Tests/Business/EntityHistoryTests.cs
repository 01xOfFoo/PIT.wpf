using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business;
using PIT.Business.Entities;

namespace PIT.Tests.Business
{
    [TestClass]
    public class EntityHistoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaisesExceptionIfEntityIsNull()
        {
            var history = new EntityHistory<Project>(null);
            history.Restore();
        }

        [TestMethod]
        public void ConsumesPropertiesAndRestoresThem()
        {
            var project = new Project {Id = 1, Short = "1", Description = "2", CreatedAt = "today"};
            var history = new EntityHistory<Project>(project);

            project.Id = 0;
            project.Short = "";
            project.Description = "";
            project.CreatedAt = "";

            history.Restore();

            Assert.AreEqual(1, project.Id);
            Assert.AreEqual("1", project.Short);
            Assert.AreEqual("2", project.Description);
            Assert.AreEqual("today", project.CreatedAt);
        }
    }
}