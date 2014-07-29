using Caliburn.Micro;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels
{
    public class ViewModel<T> : PropertyChangedBase where T : Entity
    {
    }
}