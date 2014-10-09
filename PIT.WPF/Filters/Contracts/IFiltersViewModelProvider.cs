using System.Collections.Generic;
using PIT.WPF.ViewModels.Issues.Filters;

namespace PIT.WPF.Filters.Contracts
{
    public interface IFiltersViewModelProvider
    {
        IReadOnlyCollection<FilterViewModel> Provide();
    }
}