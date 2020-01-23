using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Paket.MyNotes.Business;
using Paket.MyNotes.Business.Abstract;
using Paket.MyNotes.DataAccess.Abstract;
using Paket.MyNotes.DataAccess.EntityFramework;
using Paket.MyNotes.Entities;
using Paket.MyNotes.WebapiServis;
using Paket.MyNotes.WebapiServis.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;




namespace Paket.MyNotes.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region MySqlServer Connection Aktif
            
            services.AddDbContext<MyNotesDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlDefaultConnection"), b => b.MigrationsAssembly("AFirmasi.MyNotes.WebapiServis")));

            
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlIdentityConnection"), b => b.MigrationsAssembly("AFirmasi.MyNotes.WebapiServis")));

            #endregion


            #region Dependency Injections
            services.AddScoped<INoteService, NoteManager>();
            services.AddScoped<INoteRepository, NoteDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryDal>();
            services.AddScoped<ICommon, WebCommon>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/node",
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
