using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFirmasi.MyNotes.Business;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.DataAccess.EntityFramework;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis;
using AFirmasi.MyNotes.WebapiServis.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;




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
