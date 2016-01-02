using Castle.Windsor;
using Repositories;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApi.CastleWindsor;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static WindsorContainer _container = new WindsorContainer();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebApi.BootStrapper.Init(GlobalConfiguration.Configuration);

            //Wire-up dependencies
            _container.Install(new RepositoriesInstaller(),
                new WebApiInstaller());
            GlobalConfiguration.Configuration.DependencyResolver = new WebApi.CastleWindsor.DependencyResolver(_container.Kernel);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _container.Dispose();
        }
    }
}
