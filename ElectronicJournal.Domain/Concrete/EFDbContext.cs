using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
	}
}
