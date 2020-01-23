using Paket.MyNotes.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Paket.MyNotes.DataAccess.EntityFramework
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MyNotesDbContext>();
            
            //context.Database.EnsureCreated();// Database yoksa oluşturur.
            
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
