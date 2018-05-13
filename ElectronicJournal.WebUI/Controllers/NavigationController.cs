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
        public PartialViewResult Menu(string Category = null)
        {
			ViewBag.SelectedCategory = Category;

			//Убрать после того как тоха починит БД
			foreach (var item in repository.troops)
			{
				if (item.Disciplines == null)
				{
					item.Disciplines = new List<Domain.Entites.Discipline>();
				}
				for (int i = 1; i <= 3; i++)
				{
					item.Disciplines.Add(new Domain.Entites.Discipline
					{
						Name = "test" + i,
						Troop = item,
						TroopId = item.TroopId,
						DisciplineId = item.TroopId + i
					});
					}
			}
			//

            return PartialView(repository);
        }
    }
}