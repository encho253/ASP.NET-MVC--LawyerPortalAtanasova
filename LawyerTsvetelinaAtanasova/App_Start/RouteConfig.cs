using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace LawyerTsvetelinaAtanasova
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            routes.MapRoute(
                "BG",
                "{action}",
                new
                {
                    controller = "Home",
                    action = "Начало"
                });

            routes.MapRoute(
                "DE",
                "{action}",
                new
                {
                    controller = "Home",
                    action = "StartSeite"
                });


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
