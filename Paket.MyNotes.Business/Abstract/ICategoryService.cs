using AFirmasi.MyNotes.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AFirmasi.MyNotes.Business.Abstract
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetAllByUser();

        Category GetById(int id);

        Category GetByIdByUser(int Id);

        IQueryable<Category> GetEx(Expression<Func<Category, bool>> predicate);

        void Add(Category entity);

        void Update(Category entity);

        void Delete(Category entity);

        int Save();               

    }
}
