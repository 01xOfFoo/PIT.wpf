using System;

namespace PIT.Core
{
    public interface IEvents : IObservable<object>
    {
        void Publish(object o);
    }
}