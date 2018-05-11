using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Domain.Entites
{
    public class Theme
    {
        public Theme()
        {

        }

        [Key]
        public int ThemeId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Title{ get; set; }
        /// <summary>
        ///Количество часов
        /// </summary>
        public int AmountHours { get; set; }
        /// <summary>
        ///День
        /// </summary>
        public DateTime Day { get; set; }

        public int? DisciplineId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("DisciplineId")]
        public Discipline Discipline { get; set; }
    }
}
