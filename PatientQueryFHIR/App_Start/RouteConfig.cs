﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PatientQueryFHIR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "PatientInfoForm", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Index",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             );


        }
    }
}
