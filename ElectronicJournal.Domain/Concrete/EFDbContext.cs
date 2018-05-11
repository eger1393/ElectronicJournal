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
        public DbSet<Troop> Troops { get; set; }
        public DbSet<Prepod> Prepods { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Theme> Themes { get; set; }

    }
}
