using System;
using EducationManagementStudio.Data;
using EducationManagementStudio.Models.AccountModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace EducationManagementStudio
{
    public class Startup
    {
        private const string DbConnectionString = "Server=(localdb)\\mssqllocaldb;Database=EducationManagementStudio;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void ConfigureServices(IServiceCollection services)
        {
            AddDbServices(services);
            AddIdentityServices(services);
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvcWithDefaultRoute();
        }

        private void AddDbServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DbConnectionString));
        }

        private void AddIdentityServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddIdentity<Student, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddIdentity<Teacher, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        private ApplicationDbContext GetDbContext()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptionsBuilder.UseSqlServer(DbConnectionString);
            var dbOptions = dbOptionsBuilder.Options;

            var db = new ApplicationDbContext(dbOptions);

            return db;
        }
    }
}
