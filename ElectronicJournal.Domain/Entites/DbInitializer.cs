using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ElectronicJournal.Domain.Entites
{
    public class DbInitializer : DropCreateDatabaseAlways<Concrete.EFDbContext>
    {
        protected override void Seed(Concrete.EFDbContext db)
        {
            List<Theme> temp_list_th = new List<Theme>();
            temp_list_th.Add(new Theme { Title = "1 тема" });

            List<Discipline> temp_list_ds = new List<Discipline>();
            //temp_list_ds.Add(new Discipline { Name = "РЛС", Theme = temp_list_th });

            db.Troops.Add(new Troop { Number = "410", Disciplines = temp_list_ds });

            db.Students.Add(new Student { FIO = "Ivanov I. I." });
            db.Students.Add(new Student { FIO = "Sidorov S. A."});
            db.Students.Add(new Student { FIO = "Petrov S. A" });
            db.Students.Add(new Student { FIO = "Shavrin S. S." });

            base.Seed(db);
        }
    }
}
