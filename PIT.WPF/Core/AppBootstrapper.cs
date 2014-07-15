using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Contracts;

namespace PIT.WPF.Core
{
    public class AppBootstrapper : Bootstrapper<IShellViewModel>
    {
        private CompositionContainer _container;

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }

        protected override void Configure()
        {
            var catalog = new AggregateCatalog(new AssemblyCatalog(typeof(App).Assembly));

            var directoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            if (directoryPath != null)
            {
                var directoryCatalog = new DirectoryCatalog(directoryPath, "PIT.*.dll");
                catalog.Catalogs.Add(directoryCatalog);
            }

            _container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator()); 
            batch.AddExportedValue(_container);
            
            _container.Compose(batch);
         }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            object export = _container.GetExportedValues<object>(contract).FirstOrDefault();
            if (export != null)
            {
                return export;
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }
    }
}
