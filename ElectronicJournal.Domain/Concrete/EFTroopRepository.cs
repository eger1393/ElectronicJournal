using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Domain.Concrete
{
   public class EFTroopRepository : Abstract.ITroopRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Entites.Troop> troops { get { return context.Troops; } }
        
    }
}
