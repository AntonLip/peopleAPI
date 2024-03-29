﻿using System;

namespace PeopleAPI.Models.DTOModels
{

    public class DisciplinesFilter
    {
        public FilterFields FilterBy { get; set; }
        public string SortBy { get; set; }
    }
    public class FilterFields
    {
        public string Lectural { get; set; }
        public string AuditoreNumber { get; set; }
        public string Discipline { get; set; }
        public string Group { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
