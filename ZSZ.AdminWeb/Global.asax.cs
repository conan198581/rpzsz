using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZSZ.AdminWeb.Filters;
using ZSZ.CommonMVC;
using Autofac.Integration.Mvc;
using System.Reflection;
using ZSZ.IService;

namespace ZSZ.AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new AdminWebExceptionFilter());
            GlobalFilters.Filters.Add(new JsonNetResultFilter());
            ModelBinders.Binders.Add(typeof(string), new TrimToDBCModelBinder());

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            Assembly[] assemblies = new Assembly[] { Assembly.Load("ZSZ.Service") };
            /*
            containerBuilder.RegisterAssemblyTypes(assemblies).Where(type => !type.IsAbstract && typeof(IServiceSupport).IsAssignableFrom(type)).AsImplementedInterfaces().PropertiesAutowired();
            */
            containerBuilder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().PropertiesAutowired();
            var builder = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
