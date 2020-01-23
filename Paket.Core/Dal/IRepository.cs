using Paket.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Paket.Core.Dal
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetEx(Expression<Func<T, bool>> predicate);
        
        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Save();
    }
}
