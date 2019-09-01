using AFirmasi.MyNotes.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MyNotesDbContext>();
            
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
