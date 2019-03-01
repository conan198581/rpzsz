using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZSZ.CommonMVC;
using ZSZ.FrontWeb.Filters;
using Autofac.Integration.Mvc;
using System.Reflection;
using ZSZ.IService;

namespace ZSZ.FrontWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            GlobalFilters.Filters.Add(new FrontWebExceptionFilter());
            ModelBinders.Binders.Add(typeof(string), new TrimToDBCModelBinder());


            var cb = new ContainerBuilder();
            cb.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            Assembly[] assemblies = new Assembly[] { Assembly.Load("ZSZ.Service") };
            cb.RegisterAssemblyTypes(assemblies).Where(type => !type.IsAbstract
            &&typeof(IServiceSupport).IsAssignableFrom(type))
            .AsImplementedInterfaces().PropertiesAutowired();
            var builder = cb.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder));
            //typeof(IServiceSupport).IsAssignableFrom(type)  表示type 是否可以赋值给IServiceSupport变量，根据里氏替换原则，实现IServiceSupport接口的子类对象 可以赋值给 IServiceSupport接口的变量。多态；也就是表示 只有实现 IServiceSupport接口的类 容器才生成对象 ，而不是将所有的类都生成对象。从而节省资源和开销。


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
