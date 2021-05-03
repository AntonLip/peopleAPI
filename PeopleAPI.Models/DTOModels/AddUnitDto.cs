using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOModels
{
    public class AddUnitDto
    {
        public string name { get; set; }
        public int importance { get; set; }
        public bool IsOficer { get; set; }
    }
}
