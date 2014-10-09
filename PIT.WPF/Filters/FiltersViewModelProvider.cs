using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PIT.WPF.Filters.Contracts;
using PIT.WPF.ViewModels.Issues.Filters;

namespace PIT.WPF.Filters
{
    [Export(typeof(IFiltersViewModelProvider))]
    public class FiltersViewModelProvider : IFiltersViewModelProvider
    {
        [ImportMany] private readonly ICollection<FilterViewModel> _filters = new Collection<FilterViewModel>();

        public IReadOnlyCollection<FilterViewModel> Provide()
        {
            return (IReadOnlyCollection<FilterViewModel>) _filters;
        }
    }
}