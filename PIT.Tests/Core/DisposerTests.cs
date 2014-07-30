using System.Reactive.Disposables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Core;

namespace PIT.Tests.Core
{
    [TestClass]
    public class DiposerTests
    {
        private int _diposeCount;
        private Disposer _disposer;

        [TestInitialize]
        public void SetUp()
        {
            _disposer = new Disposer();
        }

        [TestMethod]
        public void AddDisposable()
        {
            _disposer.Add(Disposable.Create(() => ++_diposeCount));
        }

        [TestMethod]
        public void DisposesDisposables()
        {
            _disposer.Add(Disposable.Create(() => ++_diposeCount));
            _disposer.Dispose();
            Assert.AreEqual(1, _diposeCount);
        }
    }
}