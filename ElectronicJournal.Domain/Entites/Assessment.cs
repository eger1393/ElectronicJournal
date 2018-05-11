using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Domain.Entites
{
    public class Assessment
    {
        [Key]
        public string AssessmentId { get; set;}
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
