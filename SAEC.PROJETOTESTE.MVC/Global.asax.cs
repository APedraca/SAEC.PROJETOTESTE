using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SAEC.PROJETOTESTE.IOC.Ninject;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Kernel), "Start")]
[assembly: ApplicationShutdownMethod(typeof(Kernel), "Stop")]

namespace SAEC.PROJETOTESTE.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}