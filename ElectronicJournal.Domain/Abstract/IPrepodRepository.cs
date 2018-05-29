using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Abstract
{
    public interface IPrepodRepository
    {
        IQueryable<Entites.Prepod> Prepods { get; }
    }
}
