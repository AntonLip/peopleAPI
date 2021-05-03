using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DBModels
{
    public class Oficer : BaseMan, IMilitary, ICivil
    {
        public Oficer()
            :base()
        {

        }
       
        public Guid MilitaryRank { get ; set; }
        public string VoinName { get ; set ; }
        public string MilitaryDocs { get ; set ; }
        public int FormSec { get; set; }
        public bool IsLectural { get; set; }
        public DateTime DateFormSec { get; set; }
        public string CivilyDocument { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string WhoGetPassport { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
