using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Domain.Concrete
{
    public class EFPrepodRepository : Abstract.IPrepodRepository
    {
        EFDbContext context = new EFDbContext();
        public IQueryable<Prepod> Prepods { get { return context.Prepods; } }
    }
}
