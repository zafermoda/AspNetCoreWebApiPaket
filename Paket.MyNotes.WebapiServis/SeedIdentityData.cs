using AFirmasi.MyNotes.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebapiServis
{
    public class SeedIdentityData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string rolAdmin = "admin";
            string rolEditor = "editor";

            //context.Database.EnsureCreated();

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "zafer",
                Email = "zafer@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            if (!context.Users.Any())
            {
                var durum = await userManager.CreateAsync(user, "@Password135");

                if (durum.Succeeded)
                {
                    if (!context.Roles.Any())
                    {
                        if (await roleManager.FindByNameAsync(rolAdmin) == null)
                        {
                            var result = await roleManager.CreateAsync(new IdentityRole(rolAdmin));
                            if (result.Succeeded) await userManager.AddToRoleAsync(user, rolAdmin);
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(user, rolAdmin);
                        }

                        if (await roleManager.FindByNameAsync(rolEditor) == null)
                        {
                            await roleManager.CreateAsync(new IdentityRole(rolEditor));
                        }


                    }
                }

                
            }
        }
    }
}
