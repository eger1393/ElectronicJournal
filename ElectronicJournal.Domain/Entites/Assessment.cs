using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Entites
{
	public class Assessment
	{
		/// <summary>
		/// Оценка
		/// </summary>
		public string Grade { get; set; }
		/// <summary>
		/// Дата оценки
		/// </summary>
		public string Date { get; set; }
	}
}
