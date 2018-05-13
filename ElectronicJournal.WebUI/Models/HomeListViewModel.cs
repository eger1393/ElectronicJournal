using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.WebUI.Models
{
	public class HomeListViewModel
	{
		public Student[] Students { get; set; }
		public string Troop { get; set; }
		public List<DateTime> DaysArrival { get; set; }
		public string Discipline { get; set; }
	}
}