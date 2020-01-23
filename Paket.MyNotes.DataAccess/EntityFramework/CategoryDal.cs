using Paket.Core.EntityFramework;
using Paket.MyNotes.DataAccess.Abstract;
using Paket.MyNotes.Entities;

namespace Paket.MyNotes.DataAccess.EntityFramework
{
    public class CategoryDal : RepositoryBase<Category, MyNotesDbContext>, ICategoryRepository
    {
        public CategoryDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
