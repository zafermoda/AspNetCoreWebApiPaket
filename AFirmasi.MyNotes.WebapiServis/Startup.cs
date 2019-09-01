﻿using System.Text;
using AFirmasi.MyNotes.Business;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.DataAccess.Abstract;
using AFirmasi.MyNotes.DataAccess.EntityFramework;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Init;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AFirmasi.MyNotes.WebapiServis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            #region SqlServer Connection Pasif
            /*
            services.AddDbContext<MyNotesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Paket.MyNotes.WebapiServis")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"), b => b.MigrationsAssembly("Paket.MyNotes.WebapiServis")));
            */
            #endregion
            
            #region MySqlServer Connection Aktif
            services.AddDbContext<MyNotesDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlDefaultConnection"), b => b.MigrationsAssembly("Paket.MyNotes.WebapiServis")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlIdentityConnection"), b => b.MigrationsAssembly("Paket.MyNotes.WebapiServis")));
            #endregion

            #region Identity ve Jwt ayarları
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.User.RequireUniqueEmail = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://localhost:44346",
                        ValidateAudience = true,
                        ValidAudience = "https://localhost:44346",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AspNetCoreDersiB"))
                    };
                });
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            #region Ilk veri kayıtları
            SeedData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            SeedIdentityData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();
            #endregion

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
