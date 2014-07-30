using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace PIT.Core
{
    [Export]
    public class Disposer : IDisposable
    {
        private readonly List<IDisposable> _items = new List<IDisposable>();

        public void Dispose()
        {
            Unsubscribe();
        }

        public void Add(IDisposable item)
        {
            _items.Add(item);
        }

        private void Unsubscribe()
        {
            _items.ForEach(i => i.Dispose());
            _items.Clear();
        }
    }
}