using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.ViewModels.Contracts;

namespace PIT.WPF.Models.Loaders
{
    [Export(typeof(ILoader<,>))]
    public abstract class Loader<TViewModel, TEntity> : ILoader<TViewModel, TEntity> where TViewModel : new()
        where TEntity : class
    {
        protected readonly IBusiness<TEntity> Business;

        private readonly IViewModelFactory<TViewModel, TEntity> _factory;
        protected ObservableCollection<TViewModel> Collection;

        [ImportingConstructor]
        public Loader(IBusiness<TEntity> business, IViewModelFactory<TViewModel, TEntity> factory)
        {
            Business = business;
            _factory = factory;
        }

        public virtual void Load()
        {
            IEnumerable<TEntity> entities = GetEntites();
            List<TViewModel> viewmodels = entities.Select(e => _factory.CreateViewModel(e)).ToList();
            var collection = new ObservableCollection<TViewModel>();
            foreach (TViewModel vm in viewmodels)
                collection.Add(vm);
            SetCollection(collection);
        }

        protected abstract void SetCollection(ObservableCollection<TViewModel> collection);

        protected virtual IEnumerable<TEntity> GetEntites()
        {
            return Business.GetAll();
        }
    }
}