namespace PIT.WPF.ViewModels.Contracts
{
    public interface IViewModelFactory<TViewModel, TEntity>
    {
        TViewModel CreateViewModel(TEntity entity);
    }
}