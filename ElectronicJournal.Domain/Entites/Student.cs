using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Entites
{
	public class Student
	{
		public Student()
		{
			Assessments = new List<Assessment>();
		}
		public String FIO { get; set; }
		/// <summary>
		/// Список оценок студента
		/// </summary>
		public List<Assessment> Assessments { get; set; } 
	}
}
