using AFirmasi.MyNotes.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class MyNotesDbContext : DbContext
    {
        public MyNotesDbContext(DbContextOptions<MyNotesDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
