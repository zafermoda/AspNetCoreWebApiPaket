﻿using Paket.MyNotes.Entities;
using Paket.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Paket.MyNotes.WebapiServis.Filters
{
    public class CategoryExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                HasError = true
            };
            response.Errors.Add("Bir hata oluştu: " + context.Exception.Message);

            context.Result = new BadRequestObjectResult(response);
        }
    }
}
