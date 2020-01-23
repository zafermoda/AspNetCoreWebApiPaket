using Paket.Core.Entities;

namespace Paket.MyNotes.Entities
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Username { get; set; }
    }

    
}
