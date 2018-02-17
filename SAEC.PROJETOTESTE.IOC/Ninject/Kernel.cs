using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;

namespace SAEC.PROJETOTESTE.IOC.Ninject
{
    public static class Kernel
    {
        private static IKernel kernel = new StandardKernel(new INinjectModule[]
        {
            new ModuleRepository(), new ModuleService()
        });

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(GetKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel GetKernel()
        {
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            return kernel;
        }

        /// <summary>
        /// Método Responsável por obter instância concreta do serviço solicitado
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static object GetInstance(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public static T GetInstance<T>(Type serviceType)
        {
            return (T)kernel.TryGet(serviceType);
        }

        public static IEnumerable<object> ObterDependencias(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
