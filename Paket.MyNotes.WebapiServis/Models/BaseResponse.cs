using System;
using System.Collections.Generic;
using System.Text;

namespace AFirmasi.MyNotes.WebapiServis.Models
{
    public abstract class BaseResponse
    {
        public List<string> Errors { get; set; }

        public bool HasError { get; set; }

        public bool IsSuccessFul { get; set; }

        
    }
}
