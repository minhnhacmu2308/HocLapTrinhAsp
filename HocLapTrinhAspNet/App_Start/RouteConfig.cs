using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HocLapTrinhAspNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Course",
                url: "Course/Index/{isFree}/{page}",
                defaults: new { controller = "Course", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Course All",
             url: "Course/CourseAll/{page}",
             defaults: new { controller = "Course", action = "CourseAll", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "GetCourseByType",
               url: "Course/GetCourseByType/{courseTypeId}/{page}",
               defaults: new { controller = "Course", action = "GetCourseByType", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
