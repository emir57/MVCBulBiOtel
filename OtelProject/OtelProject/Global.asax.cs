using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#pragma warning disable CS0234 // The type or namespace name 'Optimization' does not exist in the namespace 'System.Web' (are you missing an assembly reference?)
using System.Web.Optimization;
#pragma warning restore CS0234 // The type or namespace name 'Optimization' does not exist in the namespace 'System.Web' (are you missing an assembly reference?)
using System.Web.Routing;

namespace OtelProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
