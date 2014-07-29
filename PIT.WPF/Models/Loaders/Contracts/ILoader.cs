namespace PIT.WPF.Models.Loaders.Contracts
{
    public interface ILoader<TViewModel, TEntity>
    {
        void Load();
    }
}