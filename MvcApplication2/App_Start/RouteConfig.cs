using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "routeOne",
            //    url: "Route/One/{stuff}",
            //    defaults: new { controller = "Route", action = "One", stuff = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "routeTwo",
            //    url: "Route/Two",
            //    defaults: new { controller = "Route", action = "Two"});

            //routes.MapRoute(
            //    name: "routeThree",
            //    url: "Route/Three",
            //    defaults: new { controller = "Route", action = "Three" });

            //routes.MapRoute(
            //    name: "routeFour",
            //    url: "Route/Four",
            //    defaults: new { controller = "Route", action = "Four" });

            //routes.MapRoute(
            //    name: "login",
            //    url: "Account/Login",
            //    defaults: new { controller = "Account", action = "Login" });

            //routes.MapRoute(
            //    name: "register",
            //    url: "Account/Register",
            //    defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
