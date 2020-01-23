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
    public class NoteValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<Note> response = new ServiceResponse<Note>
                {
                    Errors = context.ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage).ToList(),
                    HasError = true
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
