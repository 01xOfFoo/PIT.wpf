using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace PIT.WPF.Core
{
    public class MefServiceLocator : ServiceLocatorImplBase
    {
        private ExportProvider _provider;

        public MefServiceLocator(ExportProvider provider)
        {
            _provider = provider;
        }

        public void Dispose()
        {
            if (_provider == null)
                return;

            _provider = null;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            object export = _provider.GetExportedValues<object>(contract).FirstOrDefault();
            if (export != null)
            {
                return export;
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
			var exports = _provider.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
			return exports;
        }
    }
}