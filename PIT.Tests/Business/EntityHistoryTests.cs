using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business;
using PIT.Business.Entities;

namespace PIT.Tests.Business
{
    [TestClass]
    public class EntityHistoryTests
    {
        public class Dummy
        {
            public string ReadWrite { get; set; }

            private string _read;
            public string Read { get { return _read; } }

            public void SetRead(string readValue)
            {
                _read = readValue;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaisesExceptionIfEntityIsNull()
        {
            var history = new EntityHistory<Project>(null);
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

        [TestMethod]
        public void OnlySnapshotsPropertyWhichAreReadAndWriteable()
        {
            var dummy = new Dummy {ReadWrite = "readandwrite"};
            var history = new EntityHistory<Dummy>(dummy);

            dummy.ReadWrite = "";
            dummy.SetRead("onlyread");

            history.Restore();
            Assert.AreEqual("readandwrite", dummy.ReadWrite);
            Assert.AreEqual("onlyread", dummy.Read);
        }
    }
}