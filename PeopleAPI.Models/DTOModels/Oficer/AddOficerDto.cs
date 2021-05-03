﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOModels
{
   public class AddOficerDto
    {
        

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PathPhotoSmall { get; set; }
        public bool IsMarried { get; set; }
        public DateTime DateOfStartService { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Unit { get; set; }
        public string Position { get; set; }
        public bool IsLectural { get; set; }
        public string MilitaryRank { get; set; }
        public string VoinName { get; set; }
        public string MilitaryDocs { get; set; }
        public int FormSec { get; set; }
        public DateTime DateFormSec { get; set; }
        public string CivilyDocument { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string WhoGetPassport { get; set; }
        public string AcademicDegree { get; set; }
        public string AcademicTitle { get; set; }
    }
}
