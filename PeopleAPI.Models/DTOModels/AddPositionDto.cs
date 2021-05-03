using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOModels
{
    public class AddPositionDto
    {
        public bool IsOficer { get; set; }
        public string name { get; set; }
        public string VYC { get; set; }
        public float koeff { get; set; }
    }
}
