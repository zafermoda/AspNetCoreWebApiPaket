using AFirmasi.MyNotes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface INoteService
    {
        IQueryable<Note> GetAll();

        IQueryable<Note> GetAllByUser();

        Note GetNoteWithCategoryByUser(int noteId);

        Note GetById(int id);

        Note GetByIdByUser(int Id);

        IQueryable<Note> GetEx(Expression<Func<Note, bool>> predicate);

        void Add(Note entity);

        void Update(Note entity);

        void Delete(Note entity);

        int Save();

        List<Note> GetByCategoryIdByUser(int categoryId);

        List<Note> GetByCategoryId(int categoryId);

        Note GetNoteWithCategory(int noteId);



        
    }
}
