
using System.Collections.ObjectModel;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Issues
{
    public interface IIssueCollection
    {
        ObservableCollection<IssueViewModel> Items { get; }
        void Load(Project project);
    }
}