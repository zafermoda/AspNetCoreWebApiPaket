using Paket.Core.EntityFramework;
using Paket.MyNotes.DataAccess.Abstract;
using Paket.MyNotes.Entities;

namespace Paket.MyNotes.DataAccess.EntityFramework
{
    public class NoteDal : RepositoryBase<Note, MyNotesDbContext>, INoteRepository
    {
        public NoteDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
