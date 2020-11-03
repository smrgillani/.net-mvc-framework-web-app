using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dar_e_Arqam_pwd_isb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{did}/{type}",
                defaults: new { controller = "Redirect", action = "Index", id = UrlParameter.Optional, did = UrlParameter.Optional, type = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Student",
                url: "{controller}/{action}/{id}/{bd}",
                defaults: new { controller = "Home", action = "Abc", id = UrlParameter.Optional, bd = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Diary",
                url: "{controller}/{action}/{sid}/{did}/{type}",
                defaults: new { controller = "Diary", action = "CreateSubjectDiaryEng", sid = UrlParameter.Optional, did = UrlParameter.Optional, type = UrlParameter.Optional }
            );
        }
    }
}