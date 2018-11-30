using Crud.Infra.CrossCuting.IoC;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Aptum.CursoMvc.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Aptum.CursoMvc.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Aptum.CursoMvc.UI.MVC.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {

            var kernel = RegisterServices();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            return kernel;
        }
        private static StandardKernel RegisterServices()
        {
            return new Container().GetModule();
        }
    }
}