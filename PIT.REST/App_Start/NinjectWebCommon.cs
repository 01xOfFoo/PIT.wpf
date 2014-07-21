[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PIT.REST.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PIT.REST.App_Start.NinjectWebCommon), "Stop")]

// ReSharper disable once CheckNamespace
namespace PIT.REST.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebApiContrib.IoC.Ninject;

    using Data.Context;
    using Data.Repositories;
    using Data.Repositories.Contracts;
    using Models.Factories;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>ModelFactory
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            //Suport WebAPI Injection
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }
        
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<PITContext>().To<PITContext>().InRequestScope();
            kernel.Bind<IProjectRepository>().To<ProjectRepository>().InRequestScope();
            kernel.Bind<IIssueRepository>().To<IssueRepository>().InRequestScope();

            kernel.Bind<IModelFactory>().To<ModelFactory>().InRequestScope();
        }
    }
}