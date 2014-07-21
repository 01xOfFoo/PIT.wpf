using System.ComponentModel.Composition;
using PIT.API.Contracts;

namespace PIT.API
{
    [Export(typeof(IEnvironment))]
    class ProductionEnvironment : IEnvironment
    {
        private string _serverAdress;

        public ProductionEnvironment()
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