using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Abstract
{
    public interface IDisciplineRepository
    {
        IQueryable<Entites.Discipline> Disciplines { get; }
        void DeleteDiscipline(Entites.Discipline item);
        void AddDiscipline(string Name, int? PrepodId, int? TroopId);
    }
}
