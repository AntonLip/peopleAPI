using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DBModels
{
    public class Cadet : BaseMan, IMilitary
    {
        public Cadet()
            :base()
        {

        }
        public Guid MilitaryRank { get ; set; }
        public string VoinName { get; set; }
        public string MilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
    }
}
