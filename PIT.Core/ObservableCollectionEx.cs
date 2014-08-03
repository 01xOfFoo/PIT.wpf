using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PIT.Core
{
    public class ObservableCollectionEx<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public ObservableCollectionEx()
        {
            CollectionChanged += ObservableCollectionEx_CollectionChanged;
        }

        public ObservableCollectionEx(IEnumerable<T> collection) : base(collection)
        {
        }

        public ObservableCollectionEx(List<T> list) : base(list)
        {
        }

        public event EventHandler<T> CollectionItemPropertyChanged;

        protected virtual void OnCollectionItemPropertyChanged(T e)
        {
            var handler = CollectionItemPropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        private void ObservableCollectionEx_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                {
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }

        public virtual void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCollectionItemPropertyChanged((T)sender);
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(args);
        }
    }
}