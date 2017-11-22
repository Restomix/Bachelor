using Bacheler_work.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bacheler_work
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
        }
    }
}
