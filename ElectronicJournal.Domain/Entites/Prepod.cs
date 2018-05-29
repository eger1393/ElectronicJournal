using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElectronicJournal.Domain.Entites
{
    public class Prepod
    {
        private string signaturePath;

        [Key]
        public int PrepodId { get; set; }

        public virtual List<Troop> Troops { get; set; }
        public virtual List<Discipline> Disciplines { get; set; }
        public Prepod()
        {
            //FirstName = "";
            //MiddleName = "";
            //LastName = "";
            //Coolness = "";
            //Troops = new List<Troop>();
            //Disciplines = new List<Discipline>();
        }

        public string initials()
        {
            return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
        }

        public string FullSignaturePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + SignaturePath;
            }
        }
        public string SignaturePath
        {
            get
            {
                return signaturePath;
            }
            set
            {
                signaturePath = value;
            }
        }

 
        public string MiddleName
        { get; set; }

  
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        public string Coolness
        { get; set; }

        public string PrepodRank
        { get; set; }
        public string AdditionalInfo
        { get; set; }

        public override string ToString()
        {
            return Coolness + " " + MiddleName + " " + FirstName[0] + ". " + LastName[0] + ". ";
        }
    }
}
