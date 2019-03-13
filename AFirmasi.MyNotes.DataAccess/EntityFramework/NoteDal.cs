using AFirmasi.Core.EntityFramework;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class NoteDal : RepositoryBase<Note, MyNotesDbContext>, INoteRepository
    {
        public NoteDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
