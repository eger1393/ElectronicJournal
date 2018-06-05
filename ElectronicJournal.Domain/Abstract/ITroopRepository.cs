using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Abstract
{
    public interface ITroopRepository
    {
        IQueryable<Entites.Troop> troops { get; }
		void CreateDiscipline(string name, int id, int prepodId);

	}
}
