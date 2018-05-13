using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.WebUI.Models;
using System.Data.Entity.Validation;


namespace ElectronicJournal.WebUI.Controllers
{
    public class HomeController : Controller
    {
		//
		IStudentRepository repository;
		public HomeController(IStudentRepository studentsRepository)
		{
            repository = studentsRepository;
        }

		public ViewResult List(string Troop = null, string Discipline = null)
		{
			//TODOНазвание дисциплины нужно для вывода оценок
			HomeListViewModel model = new HomeListViewModel
			{
				Students = repository.students//.Where(ob => ob.Troop.Number == Troop || Troop == null)
				.OrderBy(ob => ob.FIO)
				.ToArray(),
				Troop = Troop, // нах в модели мне номер взвода и дисциплина??
				Discipline = Discipline // хотя как вариант выводить в их перед таблицей Взвод - Название дисциплины

			};
            ViewBag.Days = /*model.Students.FirstOrDefault().Troop*/new Troop().DaysArrival;
            return View(model);
        }
		[HttpPost]
		public ActionResult List(Student[] students)
		{
			for(int i = 0; i < students.Count(); i++)
			{
				if(!students[i].Equals(repository.students.ElementAt(i)))
				{
					try
					{
						repository.SaveChanges(students[i]);
					}
					catch (DbEntityValidationException ex)
					{
						
					}
				}
			}
			return RedirectToAction("List");
		}
    }
}