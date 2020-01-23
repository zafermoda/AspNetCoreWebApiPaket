using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paket.MyNotes.WebapiServis.Models
{
    public class NoteModel
    {
        [DisplayName("Not başlığı"), Required(ErrorMessage = "{0} boş geçilemez!")]
        public string NoteTitle { get; set; }

        [DisplayName("Not açıklaması"), Required(ErrorMessage = "{0} boş geçilemez!")]
        public string NoteDescription { get; set; }

        [DisplayName("Kategorisi"), Required(ErrorMessage = "{0} boş geçilemez!")]
        public int? CategoryId { get; set; }

    }
}
