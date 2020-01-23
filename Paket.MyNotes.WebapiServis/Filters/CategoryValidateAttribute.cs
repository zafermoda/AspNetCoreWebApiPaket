using Paket.MyNotes.Entities;
using Paket.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Paket.MyNotes.WebapiServis.Filters
{
    public class CategoryValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<Category> response = new ServiceResponse<Category>
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
