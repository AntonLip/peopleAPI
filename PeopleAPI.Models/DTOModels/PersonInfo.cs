using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOModels
{
    public class PersonInfoDto
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public string MilitaryRank { get; set; }
        public string TelephoneNumber { get; set; }
        public string Unit { get; set; }
    }
}
