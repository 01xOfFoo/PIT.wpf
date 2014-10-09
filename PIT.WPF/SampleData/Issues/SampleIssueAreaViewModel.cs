using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Issues.Filters.Contracts;

namespace PIT.WPF.SampleData.Issues
{
    [ExcludeFromCodeCoverage]
    internal class SampleIssueAreaViewModel : PropertyChangedBase, IIssueAreaViewModel
    {
        public SampleIssueAreaViewModel()
        {
            Issues = new ObservableCollection<IssueViewModel>
            {
                new IssueViewModel
                (
                    new Issue
                    {
                        Short = "Short1",
                        Description = "Description 1",
                        Status = IssueStatus.Open
                    }
                ),
                new IssueViewModel
                (
                    new Issue
                    {
                        Short = "Short2",
                        Description = "Description 2",
                        Status = IssueStatus.ReadyForTesting
                    }
                )
            };
        }

        public ICommand IssueDoubleClick { get; set; }
        public IIssueHeaderAreaViewModel IssueHeader { get; set; }
        public IIssueFilterAreaViewModel IssueFilter { get; set; }
        public ObservableCollection<IssueViewModel> Issues { get; set; }
    }
}