using AFirmasi.Core.Dal;
using AFirmasi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AFirmasi.Core.EntityFramework
{
    public class RepositoryBase<Tentity, Tcontext> : IRepository<Tentity>
        where Tentity : class, IEntity
        where Tcontext : DbContext
    {
        protected readonly Tcontext context;

        public RepositoryBase(Tcontext context)
        {
            this.context = context;
        }


        public void Add(Tentity entity)
        {
            context.Set<Tentity>().Add(entity);
        }

        public void Delete(Tentity entity)
        {
            context.Set<Tentity>().Remove(entity);
        }

        public IQueryable<Tentity> GetAll()
        {
            return context.Set<Tentity>();
        }        

        public Tentity GetById(int id)
        {
            return context.Set<Tentity>().Find(id);
        }

        public IQueryable<Tentity> GetEx(Expression<Func<Tentity, bool>> predicate)
        {
            return context.Set<Tentity>().Where(predicate);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Tentity entity)
        {
            context.Set<Tentity>().Update(entity);
        }
    }
}
