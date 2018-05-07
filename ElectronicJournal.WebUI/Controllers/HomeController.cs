using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.WebUI.Controllers
{
    public class HomeController : Controller
    {
		//temp
		Mock<IStudentRepository> mock = new Mock<IStudentRepository>();
		//
		IStudentRepository students;
		public HomeController(IStudentRepository studentsRepository)
		{
			students = studentsRepository;
		}
        public ActionResult List()
        {
			mock.Setup(m => m.students).Returns(new Student[]
			{
				new Student{FIO = "Ivanov I. I."},
				new Student{FIO = "Sidorov S. A."},
				new Student{FIO = "Petrov S. A"},
				new Student{FIO = "Shavrin S. S."}
			});
			students = mock.Object;

            return View(students);
        }
    }
}