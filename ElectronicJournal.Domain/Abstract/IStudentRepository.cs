using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Abstract
{
	public interface IStudentRepository
	{
		IQueryable<Student> students { get;}
		void SaveChanges(Student student);
	}
}
