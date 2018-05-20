using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZVV_Web_Lab_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "", 
                url: "catalog", 
                defaults: new { controller = "GW",
                                action = "List",
                                page = 1,
                                group = (string)null});

            routes.MapRoute(
                name: "", 
                url: "catalog/page{page}", 
                defaults: new { controller = "GW",
                                action = "List",
                                group = (string)null }, 
                                constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "", 
                url: "catalog/{group}", 
                defaults: new { controller = "GW",
                                action = "List",
                                page = 1 });

            routes.MapRoute(
                name: "", 
                url: "catalog/{group}/page{page}", 
                defaults: new { controller = "dish",
                                action = "List" }, 
                                constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home",
                                action = "Index",
                                id = UrlParameter.Optional });
        }
    }
}