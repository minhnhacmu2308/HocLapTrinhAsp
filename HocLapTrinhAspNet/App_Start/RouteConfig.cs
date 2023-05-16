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

        /*    routes.MapRoute(
           name: "Detail COurse",
           url: "Course/Detail/{id}/{mess}",
           defaults: new { controller = "Course", action = "Detail", id = UrlParameter.Optional }
       );*/
            routes.MapRoute(
           name: "News All",
           url: "News/Index/{page}",
           defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional }
       );
            routes.MapRoute(
          name: "Payment momo",
          url: "Course/PaymentMoMo/{courseId}",
          defaults: new { controller = "Course", action = "PaymentMoMo", id = UrlParameter.Optional }
      );
            routes.MapRoute(
               name: "GetCourseByType",
               url: "Course/GetCourseByType/{courseTypeId}/{page}",
               defaults: new { controller = "Course", action = "GetCourseByType", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Search",
              url: "Course/SearchCourse/{keySearch}/{page}",
              defaults: new { controller = "Course", action = "SearchCourse", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
