using Paket.MyNotes.Business.Abstract;
using Paket.MyNotes.DataAccess.Abstract;
using Paket.MyNotes.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Paket.MyNotes.Business
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ICommon common;

        public CategoryManager(ICategoryRepository categoryRepository, ICommon common)
        {
            this.categoryRepository = categoryRepository;
            this.common = common;
        }

        public void Add(Category entity)
        {
            entity.Username = common.GetCurrentUsername();
            categoryRepository.Add(entity);
            Save();
        }

        public void Delete(Category entity)
        {
            categoryRepository.Delete(entity);
            Save();
        }

        public IQueryable<Category> GetAll()
        {
            //return CategoryRepository.GetEx(x => x.Username == common.GetCurrentUsername());
            return categoryRepository.GetAll();
        }

        public IQueryable<Category> GetAllByUser()
        {            
            return categoryRepository.GetEx(p => p.Username == common.GetCurrentUsername());
        }        

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public Category GetByIdByUser(int Id)
        {
            return categoryRepository.GetEx(x => x.Id == Id && x.Username == common.GetCurrentUsername()).FirstOrDefault();
        }

        public IQueryable<Category> GetEx(Expression<Func<Category, bool>> predicate)
        {
            return categoryRepository.GetEx(predicate);
        }
        
        public int Save()
        {
            return categoryRepository.Save();
        }

        public void Update(Category entity)
        {
            entity.Username = common.GetCurrentUsername();
            categoryRepository.Update(entity);
            Save();
        }
    }
}
