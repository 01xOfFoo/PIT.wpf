using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using PIT.API.Contracts;

namespace PIT.API
{
    [Export(typeof(IEnvironment))]
    class TestEnvironment : IEnvironment
    {
        private string _serverAdress;

        public TestEnvironment()
        {
            _serverAdress = "http://localhost:3726";
        }

        public string ServerAdress
        {
            get { return _serverAdress; }
            set { _serverAdress = value; }
        }
    }
}