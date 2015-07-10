using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Reflection;
using IoCContainer;

namespace Web.Infrastructure
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        private readonly Container container;

        public CustomControllerFactory(Container container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {

            return container.Resolve(controllerType) as Controller;
        }
       
    }
}