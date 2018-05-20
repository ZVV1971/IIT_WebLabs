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
                defaults: new { controller = "GW",
                                action = "List" }, 
                                constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "editing of wares",
                url: "wares_edit",
                defaults: new
                {
                    controller = "Admin",
                    action = "Index"
                });

            routes.MapRoute(
                name: "",
                url: "wares_edit/{id}",
                defaults: new
                {
                    controller = "Admin",
                    action = "Edit"},
                 constraints: new { id = @"\d+" });

            routes.MapRoute(
                name: "creating of wares",
                url: "wares_new",
                defaults: new
                {
                    controller = "Admin",
                    action = "Create"
                });

            routes.MapRoute(
                name: "deleting of wares",
                url: "wares_delete",
                defaults: new
                {
                    controller = "Admin",
                    action = "Delete"
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home",
                                action = "Index",
                                id = UrlParameter.Optional });
        }
    }
}