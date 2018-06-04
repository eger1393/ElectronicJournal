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
		IStudentRepository repository_students;
        ITroopRepository repository_troops;
        public HomeController(IStudentRepository studentsRepository, ITroopRepository troopsRepository)
		{
			repository_students = studentsRepository;
            repository_troops = troopsRepository;
       }

		public ViewResult List(string Troop = null, string Discipline = null)
		{
			//TODOНазвание дисциплины нужно для вывода оценок
			HomeListViewModel model = new HomeListViewModel
			{
				Students = repository_students.students.Where(ob => (ob.Troop.Number == Troop || Troop == null))
				.OrderBy(ob => ob.FIO)
				.ToArray(),
				Troop = Troop, // нах в модели мне номер взвода и дисциплина??
				Discipline = Discipline, // хотя как вариант выводить в их перед таблицей Взвод - Название дисциплины
				DaysArrival = new Troop().DaysArrival
			};


            //if (model.Students.First().Assessments.Count() == 0)
            //{
            //	foreach (var Dis in model.Students.First().Troop.Disciplines)
            //	{
            //		foreach (var item in model.Students)
            //		{
            //			item.Assessments = new List<Assessment>();
            //			for (int i = 0; i < model.Students.First().Troop.DaysArrival.Count(); i++)
            //			{
            //				item.Assessments.Add(new Assessment { Theme = new Theme { Discipline = Dis } });
            //			}
            //		}
            //	}
            //}

            //Говнокод
            //if (Discipline != null)
            //{
            //	foreach (var item in model.Students)
            //	{
            //		item.Assessments = item.Assessments.Where(ob => ob.Theme.Discipline.Name == Discipline).ToList();
            //	}
            //}
            //ViewBag.Days = /*model.Students.FirstOrDefault().Troop*/new Troop().DaysArrival;
            var temp = repository_students.students.First();
            return View(model);
		}
		[HttpPost]
		public ActionResult List(Student[] students)
		{
            
            foreach (var item in students)
            {
                item.Troop = repository_troops.troops.FirstOrDefault(u => u.TroopId == item.TroopId);

                if (!(item.Equals(repository_students.students.FirstOrDefault(u => u.Id == item.Id))))
                {
                    try
                    {
                        repository_students.SaveChanges(item);
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