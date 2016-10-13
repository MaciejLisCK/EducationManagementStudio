using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EducationManagementStudio.Data;

namespace EducationManagementStudio.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161013121721_Added-IsYearRepresentative-to-Student")]
    partial class AddedIsYearRepresentativetoStudent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EducationManagementStudio.Models.AccountModels.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.AccountModels.StudentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StudentGroup");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.ClassModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<int?>("ExerciseId");

                    b.Property<int?>("NextClassesId");

                    b.Property<int>("Order");

                    b.Property<int?>("ReportId");

                    b.Property<int?>("TestId");

                    b.Property<string>("Topic")
                        .HasAnnotation("MaxLength", 1000);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("NextClassesId");

                    b.HasIndex("ReportId");

                    b.HasIndex("TestId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CourseModels.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatorId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CourseModels.CourseToStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId")
                        .IsRequired();

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseToStudent");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageContentModels.CustomPageContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CustomPageContent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CustomPageContent");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageModels.CustomPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.ToTable("CustomPage");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageModels.CustomPageToCustomPageContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomPageContentId")
                        .IsRequired();

                    b.Property<int>("CustomPageId");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.HasIndex("CustomPageContentId");

                    b.HasIndex("CustomPageId");

                    b.ToTable("CustomPageToCustomPageContent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.AccountModels.Student", b =>
                {
                    b.HasBaseType("EducationManagementStudio.Models.AccountModels.ApplicationUser");

                    b.Property<int>("GroupId");

                    b.Property<string>("IndexNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<bool>("IsYearRepresentative");

                    b.HasIndex("GroupId");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.AccountModels.Teacher", b =>
                {
                    b.HasBaseType("EducationManagementStudio.Models.AccountModels.ApplicationUser");


                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageContentModels.CustomPageAlertContent", b =>
                {
                    b.HasBaseType("EducationManagementStudio.Models.CustomPageContentModels.CustomPageContent");

                    b.Property<int?>("AlertType");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.ToTable("CustomPageAlertContent");

                    b.HasDiscriminator().HasValue("CustomPageAlertContent");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageContentModels.CustomPagePanelContent", b =>
                {
                    b.HasBaseType("EducationManagementStudio.Models.CustomPageContentModels.CustomPageContent");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Heading");

                    b.ToTable("CustomPagePanelContent");

                    b.HasDiscriminator().HasValue("CustomPagePanelContent");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.ClassModels.Class", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.CourseModels.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId");

                    b.HasOne("EducationManagementStudio.Models.CustomPageModels.CustomPage", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("EducationManagementStudio.Models.CustomPageModels.CustomPage", "NextClasses")
                        .WithMany()
                        .HasForeignKey("NextClassesId");

                    b.HasOne("EducationManagementStudio.Models.CustomPageModels.CustomPage", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId");

                    b.HasOne("EducationManagementStudio.Models.CustomPageModels.CustomPage", "Test")
                        .WithMany()
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CourseModels.Course", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.AccountModels.Teacher", "Creator")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CourseModels.CourseToStudent", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.CourseModels.Course", "Course")
                        .WithMany("CoursesToStudents")
                        .HasForeignKey("CourseId");

                    b.HasOne("EducationManagementStudio.Models.AccountModels.Student", "Student")
                        .WithMany("CoursesToStudents")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("EducationManagementStudio.Models.CustomPageModels.CustomPageToCustomPageContent", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.CustomPageContentModels.CustomPageContent", "CustomPageContent")
                        .WithMany("CustomPagesToCustomPageContents")
                        .HasForeignKey("CustomPageContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EducationManagementStudio.Models.CustomPageModels.CustomPage", "CustomPage")
                        .WithMany("CustomPagesToCustomPageContents")
                        .HasForeignKey("CustomPageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.AccountModels.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.AccountModels.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EducationManagementStudio.Models.AccountModels.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EducationManagementStudio.Models.AccountModels.Student", b =>
                {
                    b.HasOne("EducationManagementStudio.Models.AccountModels.StudentGroup", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
