using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service;
using PIT.Business.Service.Contracts;

namespace PIT.Tests.Business.Service
{
    [TestClass]
    public class ProjectBusinessTests
    {
        private IProjectBusiness _projectBusiness;
        private Mock<IProjectClient> _projectClient;

        [TestInitialize]
        public void SetUp()
        {
            _projectClient = new Mock<IProjectClient>();

            var clientProvider = new Mock<IClientProvider>();
            clientProvider.SetupGet(p => p.ProjectClient).Returns(_projectClient.Object);

            _projectBusiness = new ProjectBusiness(clientProvider.Object);    
        }

        [TestMethod]
        public void ReturnsProjectOfId()
        {
            var project = new Project() {Id = 999};
            _projectClient.Setup(c => c.GetById(It.IsAny<int>())).Returns(project);
            var receivedProject = _projectBusiness.GetById(1);

            Assert.AreEqual(project, receivedProject);
        }

        [TestMethod]
        public void ReturnsAllProjects()
        {
            var projects = new List<Project>();
            _projectClient.Setup(c => c.GetAll()).Returns(projects);
            var receivedProjects = _projectBusiness.GetAll();

            Assert.AreEqual(projects, receivedProjects);
        }

        [TestMethod]
        public void ForwardCreateProjectToClient()
        {
            _projectBusiness.Create(new Project());
            _projectClient.Verify(c => c.Create(It.IsAny<Project>()));
        }

        [TestMethod]
        public void ForwardUpdateProjectToClient()
        {
            _projectBusiness.Update(new Project());
            _projectClient.Verify(c => c.Update(It.IsAny<Project>()));
        }

        [TestMethod]
        public void ForwardDeleteProjectToClient()
        {
            _projectBusiness.Delete(new Project());
            _projectClient.Verify(c => c.Delete(It.IsAny<Project>()));
        }
    }
}
