using Newtonsoft.Json;
using System.Collections.Generic;

namespace AFirmasi.MyNotes.WebapiServis.Models
{
    public class ServiceResponse<T> : BaseResponse
    {
        [JsonProperty]
        public T Entity { get; set; }

        [JsonProperty]
        public List<T> Entities { get; set; }

        public int EntitiesCount { get; set; }

        public ServiceResponse()
        {
            Errors = new List<string>();
            Entities = new List<T>();
        }



    }
}
