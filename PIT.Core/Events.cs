using System;
using System.ComponentModel.Composition;
using System.Reactive.Subjects;

namespace PIT.Core
{
    [Export(typeof(IEvents))]
    public class Events : IEvents, IObservable<object>
    {
        private static readonly IEvents _current = new Events();
        public static IEvents Current
        {
            get { return _current; }
        }
        private readonly Subject<object> _events;

        public Events()
        {
            _events = new Subject<object>();
        }

        public void Publish(object e)
        {
            _events.OnNext(e);
        }

        public IDisposable Subscribe(IObserver<object> observer)
        {
            return _events.Subscribe(observer);
        }
    }
}