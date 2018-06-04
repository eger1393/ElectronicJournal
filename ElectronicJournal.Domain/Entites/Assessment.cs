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
        public Assessment()
        {
           
        }
        public Assessment(Theme temp)
		{
            Theme = temp;
		}
        [Key]
        public int AssessmentId { get; set;}
        /// <summary>
        /// Оценка
        /// </summary>
        /// 
        public int? StudentId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public string Grade { get; set; }
		public int? ThemeId { get; set; }
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey("ThemeId")]
		public virtual Theme Theme { get; set; }
	}
}
