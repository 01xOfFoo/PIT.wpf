using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Loaders;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.Tests.WPF.Models.Projects
{
    [TestClass]
    public class ProjectsLoaderTests
    {
        private Mock<IProjectBusiness> _business;
        private ProjectsLoader _loader;
        private ProjectSelection _selection;
        private Mock<IViewModelFactory<ProjectViewModel, Project>> _viewModelFactory;

        [TestInitialize]
        public void SetUp()
        {
            _selection = new ProjectSelection();
            _viewModelFactory = new Mock<IViewModelFactory<ProjectViewModel, Project>>();
            _business = new Mock<IProjectBusiness>();

            var projects = new List<Project>
            {
                new Project()
            };
            _business.Setup(b => b.GetAll()).Returns(projects);

            _loader = new ProjectsLoader(_business.Object, _viewModelFactory.Object, _selection);
        }

        [TestMethod]
        public void LoadsProjects()
        {
            _loader.Load();
            Assert.AreEqual(1, _selection.Projects.Count);
        }
    }
}