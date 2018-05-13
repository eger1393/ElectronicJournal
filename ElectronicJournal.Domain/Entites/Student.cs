using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Domain.Entites
{
	public class Student
	{
		public Student()
		{
			Assessments = new List<Assessment>();
		}

        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }

        public int? TroopId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TroopId")]
        public virtual Troop Troop { get; set; }

        /// <summary>
        /// Список оценок студента
        /// </summary>
        public virtual List<Assessment> Assessments { get; set; } 
	}
}
