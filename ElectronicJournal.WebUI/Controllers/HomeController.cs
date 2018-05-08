using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.Concrete; //


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

			mock.Setup(m => m.students).Returns(new Student[]
			{
				new Student{FIO = "Ivanov I. I."},
				new Student{FIO = "Sidorov S. A."},
				new Student{FIO = "Petrov S. A"},
				new Student{FIO = "Shavrin S. S."}
			});
			students = mock.Object;
			for (int i = 0; i < 4; i++)
			{
				students.students.ElementAt(i).Assessments.Add(new Assessment());
				students.students.ElementAt(i).Assessments.Add(new Assessment());
				students.students.ElementAt(i).Assessments.Add(new Assessment());
				students.students.ElementAt(i).Assessments.Add(new Assessment());
			}
		}
        public ActionResult List()
        {

            return View(students.students.ToArray());
        }
		[HttpPost]
		public string List(Student[] students)
		{

			return "Good!";
		}
    }
}