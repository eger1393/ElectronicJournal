using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Ninject;

namespace ElectronicJournal.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new Domain.Entites.DbInitializer());
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<Domain.Concrete.EFDbContext>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			//ninject
			DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver(new StandardKernel()));
        }
    }
}
