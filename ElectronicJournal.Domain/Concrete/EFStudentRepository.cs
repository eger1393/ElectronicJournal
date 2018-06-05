using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Domain.Abstract;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Concrete
{
	public class EFStudentRepository : IStudentRepository
	{
		private EFDbContext context = new EFDbContext();

        public EFStudentRepository()
        {
            foreach (var item in students)
            {
                item.CreateAssessment();
                
            }
        }
        public IQueryable<Student> students { get { return context.Students; } }
		public void SaveChanges(Student student)
		{
			if(student.Id == 0)
			{
				context.Students.Add(student);
			}
			else
			{
				Student dbEntry = context.Students.Find(student.Id);
				if(dbEntry != null)
				{
					dbEntry.FIO = student.FIO;
					foreach (var item in student.Assessments)
					{
						if(item.AssessmentId != 0)
						{
							dbEntry.Assessments.FirstOrDefault(ob => ob.AssessmentId == item.AssessmentId).Grade = item.Grade;
						}
						else // TODO Заплатка с ИД темы переделать!
						{
							dbEntry.Assessments.Add(item);
						}
					}
					//dbEntry.Assessments = student.Assessments;
					//dbEntry.Troop = student.Troop;
					dbEntry.TroopId = student.TroopId;
				}
			}
			context.SaveChanges();
		}
	}
}
