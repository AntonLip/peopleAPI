using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.Interfaces
{
    public interface ICivil
    {
        public string CivilyDocument { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string WhoGetPassport { get; set; }

        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
