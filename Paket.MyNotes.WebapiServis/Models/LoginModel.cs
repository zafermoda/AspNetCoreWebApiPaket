using System.ComponentModel.DataAnnotations;

namespace AFirmasi.MyNotes.WebapiServis.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı giriniz!")]
        public string Password { get; set; }
    }
}
