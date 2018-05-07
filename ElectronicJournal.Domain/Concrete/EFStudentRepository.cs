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
		public IEnumerable<Student> students { get { return context.Students; } }
	}
}
