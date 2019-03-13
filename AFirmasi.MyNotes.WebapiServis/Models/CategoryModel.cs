using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebapiServis.Models
{
    public class CategoryModel
    {
        [DisplayName("Kategor adı"), Required(ErrorMessage = "{0} boş geçmeyiniz!")]
        public string CategoryName { get; set; }
    }
}
