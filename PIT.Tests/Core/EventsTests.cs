using System;
using System.Reactive.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Core;

namespace PIT.Tests.Core
{
    [TestClass]
    public class EventsTests
    {
        private Events _events;
        private int _invokeCount;

        [TestInitialize]
        public void Setup()
        {
            _events = new Events();
        }

        [TestMethod]
        public void CanPublishEvent()
        {
            _events.Publish(null);
        }

        [TestMethod]
        public void CanSubscribeEvent()
        {
            _events.Subscribe(e => { ++_invokeCount; });
            _events.Publish(null);
            Assert.AreEqual(1, _invokeCount);
        }

        [TestMethod]
        public void SubscribeForSpecificEvent()
        {
            int invokeDummyClassEvent = 0;
            _events.OfType<DummyEvent>().Subscribe(e => { ++invokeDummyClassEvent; });

            _events.Publish(new DummyEvent());
            _events.Publish(null);
            _events.Publish(new DummyEvent());

            Assert.AreEqual(2, invokeDummyClassEvent);
        }
    }

    public class DummyEvent
    {
        public string Name { get; set; }
    }
}