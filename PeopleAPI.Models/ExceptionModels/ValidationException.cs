using System;
using System.Collections.Generic;

namespace PeopleAPI.Models.ExceptionModels
{
    public class ValidationException: Exception
    {
        public List<String> ValidationErrors { get; set; }

        public ValidationException(List<String> validationErrors)
        {
            this.ValidationErrors = validationErrors;
        }

    }
}
