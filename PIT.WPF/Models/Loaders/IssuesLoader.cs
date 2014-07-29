using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Loaders
{
    [Export(typeof(ILoader<IssueViewModel, Issue>))]
    public class IssuesLoader : Loader<IssueViewModel, Issue>
    {
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public IssuesLoader(IIssueBusiness business, IViewModelFactory<IssueViewModel, Issue> factory,
            ProjectSelection projectSelection, IssueSelection issueSelection)
            : base(business, factory)
        {
            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += (s, e) => Load();

            Collection = issueSelection.Issues;
        }

        protected override IEnumerable<Issue> GetEntites()
        {
            int id = _projectSelection.SelectedProject.Id;
            return ((IIssueBusiness) Business).GetIssuesOfProject(id).Select(i => FixUpProjects(i));
        }

        private Issue FixUpProjects(Issue issue)
        {
            issue.Project = _projectSelection.SelectedProject.Project;
            return issue;
        }
    }
}