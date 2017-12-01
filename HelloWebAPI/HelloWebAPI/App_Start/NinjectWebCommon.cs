[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VoucherApiDotNetFW462.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VoucherApiDotNetFW462.App_Start.NinjectWebCommon), "Stop")]

namespace VoucherApiDotNetFW462.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using VoucherApiDotNetFW462.Dao;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
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
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var conString = ConfigurationManager.ConnectionStrings["HelloWorldModel"].ConnectionString;

            // e.g. kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IDbConnection>().To<SqlConnection>().InRequestScope();
            kernel.Bind<ISystemDao>().To<SystemDao>().InRequestScope().WithConstructorArgument("conString", conString);
        }

    }
}
