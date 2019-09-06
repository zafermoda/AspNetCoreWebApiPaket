using AFirmasi.MyNotes.Business;
using AFirmasi.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFirmasi.MyNotes.WebapiServis.Init
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
