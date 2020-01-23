using System;

namespace Paket.MyNotes.WebapiServis.Models
{
    public class TokenResponse : BaseResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
