using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Domain.Entites
{
   

    public class Troop
    {
        static string[] DaysArriv =  { "Пн","Вт", "Ср", "Чт", "Пт", };
        public Troop()
        {
            Day = DaysArriv[0];
            DaysArrival = new List<DateTime>();
            ScheduleGeneration();
        }

        [Key]
        public int TroopId { get; set; }


        /// <summary>
        /// Список студентов
        /// </summary>
        private List<Student> Students { get; set; }
        /// <summary>
        /// Номер взвода
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// День прихода
        /// </summary>
        public string Day{ get; set; }
        /// <summary>
        /// Список дней прихода взвода
        /// </summary>
        public List<DateTime> DaysArrival{ get; set; }

        /// <summary>
        /// Список дисциплин изучающихся взводом
        /// </summary>
        public List<Discipline> Disciplines { get; set; }

        public int? PrepodId { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("PrepodId")]
        public Prepod Prepod { get; set; }

        void ScheduleGeneration()
        {
            DateTime temp = new DateTime(2018, 2, 7);

            for (int i = 0; i < 16; i++)
            {
                if (temp == DateTime.MinValue)
                {
                    temp = DateTime.Today;
                   
                }
                else
                {
                    temp = temp.AddDays(7);
                }
                DaysArrival.Add(temp);
            }

            List<DateTime> holidays = new List<DateTime>{ new DateTime(DateTime.Today.Year,1,1), new DateTime(DateTime.Today.Year, 1, 2), new DateTime(DateTime.Today.Year, 1, 3),
                                    new DateTime(DateTime.Today.Year, 1, 4), new DateTime(DateTime.Today.Year, 1, 5), new DateTime(DateTime.Today.Year, 1, 6),
                                    new DateTime(DateTime.Today.Year,1,7), new DateTime(DateTime.Today.Year,1,8),   new DateTime(DateTime.Today.Year,1,8),
                                    new DateTime(DateTime.Today.Year,1,10), new DateTime(DateTime.Today.Year,2,23), new DateTime(DateTime.Today.Year,3,8),
                                    new DateTime(DateTime.Today.Year,5,1),  new DateTime(DateTime.Today.Year,5,2), new DateTime(DateTime.Today.Year,5,9),
                                    new DateTime(DateTime.Today.Year,6,12),  new DateTime(DateTime.Today.Year,11,4) };

           
            foreach (var item in holidays)
            {
                if(DaysArrival.Find(c => c == item) != null )
                {
                    DaysArrival.Remove(item);
                }
            }
        }
    }
}
