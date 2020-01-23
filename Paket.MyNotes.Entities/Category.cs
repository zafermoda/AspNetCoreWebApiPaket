
using Paket.Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Paket.MyNotes.Entities
{
    public class Category :IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; }

        public string Username { get; set; }
    }

    
}
