using AFirmasi.Core.EntityFramework;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.Entities;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class CategoryDal : RepositoryBase<Category, MyNotesDbContext>, ICategoryRepository
    {
        public CategoryDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
