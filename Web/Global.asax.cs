using IoCContainer;
using IoCContainer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Controllers;
using Web.DAL;
using Web.Infrastructure;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<UsersController, UsersController>();
            container.Register<IUserRepository, UserRepository>(LifestyleType.Singleton);

            

            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory(container));
        }
    }
}
