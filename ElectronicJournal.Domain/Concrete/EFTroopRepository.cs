using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Concrete
{
   public class EFTroopRepository : Abstract.ITroopRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entites.Troop> troops { get { return context.Troops; } }
        
		public void CreateDiscipline(string name, int id, int prepodId)
		{
			Troop temp = context.Troops.FirstOrDefault(ob => ob.TroopId == id);

			if(temp.Disciplines == null)
			{
				temp.Disciplines = new List<Discipline>();
			}
			Discipline discipline = new Discipline(temp.DaysArrival)
			{
				Name = name,
				PrepodId = prepodId,
				TroopId = temp.TroopId
			};
			temp.Disciplines.Add(discipline);
			
			foreach (var item in temp.Students)
			{
				var ob = item.CreateAssessment(discipline);
				//context.Assessments.AddRange(ob);
			}
			context.Disciplines.Add(discipline);
			context.SaveChanges();
		}
    }
}
