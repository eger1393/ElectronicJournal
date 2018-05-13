﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ElectronicJournal.Domain.Entites
{
    public class Discipline
    {
        public Discipline()
        {
            Theme = new List<Theme>();
            for (int i = 0; i < 16; i++)
            {
                Theme.Add(new Theme() { Title = "Тема"+i });
            }
        }

        public Discipline(int count_theme)
        {
            Theme = new List<Theme>();
            for (int i = 0; i < count_theme; i++)
            {
                Theme.Add(new Theme() { Title = "Тема" + i } );
            }
        }

        [Key]
        public int DisciplineId { get; set; }

        /// <summary>
        /// Список тем
        /// </summary>
        public virtual List<Theme> Theme { get; set; }
		public string Name { get; set; }

        public int? PrepodId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PrepodId")]
        public virtual Prepod Prepod { get; set; }

        public int? TroopId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TroopId")]
        public virtual Troop Troop { get; set; }

    }
}
