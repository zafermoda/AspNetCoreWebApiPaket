using Paket.MyNotes.Business;
using Paket.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paket.MyNotes.WebapiServis.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            string username = MevcutUsername.MevcutUsernameGetir;

            if (username != null)
            {
                return username;
            }
            else
            {
                return "system";
            }
        }
    }
}
