using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFirmasi.MyNotes.Business
{
    public class NoteManager : INoteService
    {
        private INoteRepository noteRepository;
        private ICommon common;

        public NoteManager(INoteRepository noteRepository, ICommon common)
        {
            this.noteRepository = noteRepository;            
            this.common = common;
        }

        public void Add(Note entity)
        {
            entity.Username = common.GetCurrentUsername();
            noteRepository.Add(entity);
            Save();
        }

        public void Delete(Note entity)
        {
            noteRepository.Delete(entity);
            Save();
        }

        public IQueryable<Note> GetAll()
        {
            //return noteRepository.GetEx(x => x.Username == common.GetCurrentUsername());
            return noteRepository.GetAll();
        }

        public IQueryable<Note> GetAllByUser()
        {            
            string userName = common.GetCurrentUsername();
            return noteRepository.GetEx(p => p.Username == userName);
        }

        public List<Note> GetByCategoryIdByUser(int categoryId)
        {
            return noteRepository.GetEx(x => x.CategoryId == categoryId && x.Username == common.GetCurrentUsername()).ToList();
        }

        public List<Note> GetByCategoryId(int categoryId)
        {
            return noteRepository.GetEx(x => x.CategoryId == categoryId).ToList();

        }

        public Note GetById(int id)
        {
            return noteRepository.GetById(id);
        }

        public Note GetByIdByUser(int Id)
        {
            return noteRepository.GetEx(x => x.Id == Id && x.Username == common.GetCurrentUsername()).FirstOrDefault();
        }

        public IQueryable<Note> GetEx(Expression<Func<Note, bool>> predicate)
        {
            return noteRepository.GetEx(predicate);
        }

        public Note GetNoteWithCategory(int noteId)
        {
            return noteRepository.GetEx(p => p.Id == noteId).Include("Category").FirstOrDefault();
        }

        public Note GetNoteWithCategoryByUser(int noteId)
        {
            return noteRepository.GetEx(x => x.Id == noteId && x.Username == common.GetCurrentUsername()).Include("Category").FirstOrDefault();
        }

        public int Save()
        {
            return noteRepository.Save();
        }

        public void Update(Note entity)
        {
            entity.Username = common.GetCurrentUsername();
            noteRepository.Update(entity);
            Save();
        }

        
    }
}
