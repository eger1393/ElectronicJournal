using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.WebUI.Controllers;
using ElectronicJournal.WebUI.Models;
using System.Web;

namespace ElectronicJournal.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void List_Navigation()
		{
			//arrange
			Mock<IStudentRepository> repo = new Mock<IStudentRepository>();
			repo.Setup(m => m.students).Returns(new Student[]
			{
				new Student {FIO = "Тест 1", Troop = new Troop {Number = "1"}},
				new Student {FIO = "Тест 2", Troop = new Troop {Number = "1"}},
				new Student {FIO = "Тест 3", Troop = new Troop {Number = "1"}},
				new Student {FIO = "Тест 4", Troop = new Troop {Number = "1"}},
				new Student {FIO = "Тест 5", Troop = new Troop {Number = "2"}},
				new Student {FIO = "Тест 6", Troop = new Troop {Number = "3"}},
			}.AsQueryable());
			//Mock<ITroopRepository> troop = new Mock<ITroopRepository>();
			//troop.Setup(m => m.troops).Returns(new Troop[]
			//{
			//	new Troop {Number = "1"},
			//	new Troop {Number = "2"},
			//	new Troop {Number = "3"}
			//});
			HomeController controller = new HomeController(repo.Object);
			//act
			Student[] result = ((HomeListViewModel)controller.List(Troop: "1").Model).Students;
			//assert
			Assert.AreEqual(4, result.Length);
		}
	}
}
