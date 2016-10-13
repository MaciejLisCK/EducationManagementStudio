using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.AccountModels;
using EducationManagementStudio.Models.CourseModels;
using EducationManagementStudio.Models.CustomPageModels;
using Microsoft.EntityFrameworkCore.Metadata;
using EducationManagementStudio.Models.CustomPageContentModels;

namespace EducationManagementStudio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentGroup> StudentGroup { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseToStudent> CourseToStudent { get; set; }
        public DbSet<CourseToGroup> CourseToGroup { get; set; }
        public DbSet<CustomPage> CustomPage { get; set; }
        public DbSet<CustomPageToCustomPageContent> CustomPageToCustomPageContent { get; set; }
        public DbSet<CustomPageContent> CustomPageContent { get; set; }
        public DbSet<CustomPagePanelContent> CustomPagePanelContent { get; set; }
        public DbSet<CustomPageAlertContent> CustomPageAlertContent { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentGroup>()
                .HasIndex(b => b.Name)
                .IsUnique();

            foreach (var courseToStudentForeignKey in modelBuilder.Entity<CourseToStudent>().Metadata.GetForeignKeys())
                courseToStudentForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var courseToStudentForeignKey in modelBuilder.Entity<CourseToGroup>().Metadata.GetForeignKeys())
                courseToStudentForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
