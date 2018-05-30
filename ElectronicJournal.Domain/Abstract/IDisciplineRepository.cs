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
        void DeleteTheme(Entites.Theme item); //наверное немного не логично что в репозитории дисциплын можно удалять тему??
        void AddTheme(int DisciplineId, string Title, int Count, DateTime Date);
    }
}
