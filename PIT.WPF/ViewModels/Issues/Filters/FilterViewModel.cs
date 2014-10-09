namespace PIT.WPF.ViewModels.Issues.Filters
{
    public abstract class FilterViewModel
    {
        private readonly string _filterName;

        public FilterViewModel(string filterName)
        {
            _filterName = filterName;
        }

        public string Name
        {
            get { return _filterName; }
        }
    }
}