using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //defining custom route through attributes
            routes.MapMvcAttributeRoutes();

            //defining route with mutiple parameters
            /*routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                new { controller="Movies",action="ByReleaseDate"},
                
                //to apply constrains
                
                //new { year=@"\d{4}",month =@"\d{2}"}
                new {year=@"2015|2016"}
                );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                
            );
        }
    }
}
