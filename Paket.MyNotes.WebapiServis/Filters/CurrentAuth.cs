using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Init;
using AFirmasi.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace AFirmasi.MyNotes.WebapiServis.Filters
{
    public class CurrentAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User != null)
            {
                MevcutUsername.MevcutUsernameGetir = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            else
            {
                MevcutUsername.MevcutUsernameGetir = "system";
            }

            
        }
    }
}
