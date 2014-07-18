using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using Caliburn.Micro;
using PIT.WPF.ViewModels;

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

            var mefLocator = new MefServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => mefLocator);
         }
        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return ServiceLocator.Current.GetInstance(serviceType, key);
        }
    }
}
