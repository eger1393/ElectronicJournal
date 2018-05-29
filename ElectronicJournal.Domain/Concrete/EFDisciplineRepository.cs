using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Concrete
{
    public class EFDisciplineRepository : Abstract.IDisciplineRepository
    {
        EFDbContext context = new EFDbContext();
        public IQueryable<Discipline> Disciplines { get { return context.Disciplines; } }
        public void DeleteDiscipline(Discipline item)
        {
            // TODO узнать где хранятся оценки и реализовать удалене оценок при их наличии
            List<Theme> themes = item.Theme.ToList();
            foreach (var theme in themes)
            {
                context.Themes.Remove(theme);
            }
            context.Disciplines.Remove(item);
            context.SaveChanges();
        }
        public void AddDiscipline(string Name, int? PrepodId, int? TroopId)
        {
            context.Disciplines.Add(new Discipline
            {
                Name = Name,
                PrepodId = PrepodId,
                TroopId = TroopId
            });
            context.SaveChanges();
        }
    }
}
