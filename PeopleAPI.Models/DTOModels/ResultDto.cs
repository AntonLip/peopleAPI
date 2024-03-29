﻿using System.Collections.Generic;

namespace PeopleAPI.Models.DTOModels
{
    public class ResultDto<TModel>
    {
        public TModel Value { get; set; }

        public List<string> Errors { get; set; }
    }
}
