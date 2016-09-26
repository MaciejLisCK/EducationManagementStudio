using EducationManagementStudio.Data;
using EducationManagementStudio.Models.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EducationManagementStudio
{
    public class Startup
    {
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

        public void DbTest()
        {
            var sqlDatabaseString = "Server=(localdb)\\mssqllocaldb;Database=EducationManagementStudio;Trusted_Connection=True;MultipleActiveResultSets=true";
            var dbOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbOptionsBuilder.UseSqlServer(sqlDatabaseString);
            var dbOptions = dbOptionsBuilder.Options;

            var db = new ApplicationDbContext(dbOptions);
        }

        private void AddDbServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EducationManagementStudio;Trusted_Connection=True;MultipleActiveResultSets=true"));
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
    }
}
