using System;
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
			//Theme = new List<Theme>();
			//for (int i = 0; i < 16; i++)
			//{
			//    Theme.Add(new Theme() { Title = "Тема" + i });
			//}
		}

		public Discipline(List<DateTime> List_Themes)
		{
			Theme = new List<Theme>();
			foreach (var item in List_Themes)
			{
				Theme.Add(new Theme(item.Date)
				{
					DisciplineId = DisciplineId,
					Discipline = this,
					Title = "Тема" + item.Second
				});
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
