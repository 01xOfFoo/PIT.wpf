using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PIT.Tests.WPF.Models
{
    [TestClass]
    public class ProjectsLoaderTests
    {
        [TestMethod]
        public void CanCreate()
        {
            var loader = new ProjectsLoader();
        }
    }
}