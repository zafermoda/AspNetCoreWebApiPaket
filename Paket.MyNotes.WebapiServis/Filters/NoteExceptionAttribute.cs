using Paket.MyNotes.Entities;
using Paket.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paket.MyNotes.WebapiServis.Filters
{
    public class NoteExceptionAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                HasError = true
            };
            response.Errors.Add("Bir hata oluştu: " + context.Exception.Message);

            context.Result = new BadRequestObjectResult(response);
        }
    }
}
