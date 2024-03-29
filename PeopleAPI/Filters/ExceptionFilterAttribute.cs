﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PeopleAPI.Models.DTOModels;


namespace PeopleAPI.Filters
{
    public class ExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                switch (context.Exception)
                {
                    case InvalidOperationException error:
                        context.Result = new BadRequestObjectResult(new ResultDto<object>()
                        {
                            Errors = new List<string>()
                            {
                                error.Message
                            }
                        });
                        break;
                    case ArgumentException error:
                        context.Result = new BadRequestObjectResult(new ResultDto<object>()
                        {
                            Errors = new List<string>()
                            {
                                error.Message
                            }
                        });
                        break;
                    case Models.ExceptionModels.ValidationException error:
                        context.Result = new BadRequestObjectResult(new ResultDto<object>()
                        {
                            Errors = error.ValidationErrors
                        });
                        break;
                    default:
                        context.Result = new ObjectResult(new ResultDto<object>()
                        {
                            Errors = new List<string>()
                            {
                                context.Exception.Message
                            }
                        })
                        { StatusCode = 500 };
                        break;
                }
            }

            return Task.FromResult<Object>(null);
        }
    }
}
