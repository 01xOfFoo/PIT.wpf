using System.Collections.ObjectModel;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Issues.Contracts
{
    public interface IIssueCollection
    {
        ObservableCollection<IssueViewModel> Items { get; }
        void Load(Project project);
    }
}