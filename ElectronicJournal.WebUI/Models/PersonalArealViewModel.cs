using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.WebUI.Models
{
    public class PersonalArealViewModel
    {
        public Prepod Prepod { get; set; }
        public List<Troop> Troops { get; set; }
        public PersonalArealViewModel()
        {
            Troops = new List<Troop>();
        }
    }
}