﻿using System;
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
        private Troop troop;
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }

        public int? TroopId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("TroopId")]
        public virtual Troop Troop {
            get
            {
                return troop;
            }
            set
            {
                troop = value;
            }
        }

        /// <summary>
        /// Список оценок студента
        /// </summary>
        public virtual List<Assessment> Assessments { get; set; } 

        public void CreateAssessment()
        {
            foreach (var item in Troop.Disciplines)
            {
                foreach (var item2 in item.Theme)
                {
                    Assessments.Add(new Assessment(Id ,item2));
                }
            }
           
        }

    }
}
