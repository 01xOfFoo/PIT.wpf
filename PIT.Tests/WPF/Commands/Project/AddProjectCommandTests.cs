﻿using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.WPF.Commands.Project;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.Tests.WPF.Commands.Project
{
    [TestClass]
    public class AddProjectCommandTests
    {
        private AddProjectCommand _command;
        private Mock<IProjectEditViewModel> _projectEditViewModelMock;
        private Mock<IProjectViewModelFactory> _projectViewModelFactory;
        private Mock<IWindowManager> _windowManager;

        [TestInitialize]
        public void SetUp()
        {
            _windowManager = new Mock<IWindowManager>();
            _projectEditViewModelMock = new Mock<IProjectEditViewModel>();
            _projectViewModelFactory = new Mock<IProjectViewModelFactory>();

            _command = new AddProjectCommand(_windowManager.Object, _projectEditViewModelMock.Object,
                _projectViewModelFactory.Object);
            _command.Execute(null);
        }

        [TestMethod]
        public void CreatesNewViewModelUsingTheFactory()
        {
            _projectViewModelFactory.Verify(f => f.CreateProjectViewModel());
        }

        [TestMethod]
        public void ActivatesNewProjectInEditViewModel()
        {
            _projectEditViewModelMock.Verify(e => e.ActivateProject(It.IsAny<ProjectViewModel>()));
        }

        [TestMethod]
        public void DisplaysEditView()
        {
            _windowManager.Verify(w => w.ShowDialog(It.IsAny<object>(), null, null));
        }
    }
}