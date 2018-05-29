using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectronicJournal.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			//routes.MapRoute(
			//	null,
			//	"",
			//	new
			//	{
			//		controller = "Home",
			//		action = "List",
			//		Troop = (string)null,
			//		Discipline = (int?)null
			//	}
			//	);
            routes.MapRoute(null, "{controller}/{action}");
			//routes.MapRoute(
			//	null,
			//	"{Troop}",
			//	new { controller = "Home", action = "List", Discipline = (int?)null}
			//	);
			//routes.MapRoute(
			//	null,
			//	"{Troop}/{Discipline}",
			//	new { controller = "Home", action = "List"}
			//	);


        }
    }
}
