﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DTOModels
{
    public class PositionDto
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public bool IsOficer { get; set; }

    }
}
