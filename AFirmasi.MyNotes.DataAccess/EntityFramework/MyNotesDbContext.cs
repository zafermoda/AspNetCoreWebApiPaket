using AFirmasi.MyNotes.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class MyNotesDbContext : DbContext
    {
        public MyNotesDbContext(DbContextOptions<MyNotesDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Note> Notes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
