using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.Interfaces
{
    interface IMilitary
    {
        public Guid MilitaryRank { get; set; }
        public string VoinName { get; set; }
        public string MilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
    }
}
