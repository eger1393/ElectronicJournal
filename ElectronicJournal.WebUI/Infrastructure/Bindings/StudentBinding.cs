using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.WebUI.Infrastructure.Bindings
{
	public class StudentBinding : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			Student student = new Student();
			//student.FIO = (controllerContext.Controller.)

			return student;
		}
	}
}