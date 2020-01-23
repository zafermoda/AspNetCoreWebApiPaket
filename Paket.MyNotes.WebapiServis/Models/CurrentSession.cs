using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Paket.MyNotes.WebapiServis.Models
{

    public class CurrentSession
    {
        //public static string GetCurrentUsername
        //{
        //    get
        //    {
        //        CurrentSession currents = new CurrentSession();
        //        return currents.Get();
        //    }
        //}

        HttpContext context;

        public CurrentSession(HttpContext context)
        {
            this.context = context;
        }

        public string GetCurrentUsername()
        {            
            string userName = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userName))
            {
                return userName;
            }
            else
            {
                return "system";

            }

        }

    }
}
