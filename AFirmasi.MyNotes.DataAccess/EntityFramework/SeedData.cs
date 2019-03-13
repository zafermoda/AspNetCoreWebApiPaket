using AFirmasi.MyNotes.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MyNotesDbContext>();
            var thistime = DateTime.Now;

            context.Database.EnsureCreated();
            

            Category category = new Category
            {
                CategoryName = "Sosyal Ağ"                
            };

            
            if (!context.Categories.Any())
            {
                context.Add(category);
                context.SaveChanges();
            }

            

        }
    }
}
