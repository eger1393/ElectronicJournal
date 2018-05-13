using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicJournal.Domain.Abstract; 

namespace ElectronicJournal.WebUI.Controllers
{
    public class NavigationController : Controller
    {
		private ITroopRepository repository;
		public NavigationController(ITroopRepository troopRepository)
		{
			repository = troopRepository;
		}
        // GET: Navigation
        public PartialViewResult Menu(string Troop = null)
        {
			ViewBag.SelectedTroop = Troop;

            return PartialView(repository);
        }
    }
}