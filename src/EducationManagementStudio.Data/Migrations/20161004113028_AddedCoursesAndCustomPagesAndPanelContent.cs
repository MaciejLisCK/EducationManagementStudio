using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedCoursesAndCustomPagesAndPanelContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentGroup_GroupId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CustomPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomPageContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Heading = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPageContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    StartPageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_CustomPage_StartPageId",
                        column: x => x.StartPageId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomPageToCustomPageContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomPageContentId = table.Column<int>(nullable: false),
                    CustomPageId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPageToCustomPageContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomPageToCustomPageContent_CustomPageContent_CustomPageContentId",
                        column: x => x.CustomPageContentId,
                        principalTable: "CustomPageContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomPageToCustomPageContent_CustomPage_CustomPageId",
                        column: x => x.CustomPageId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseToStudent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseToStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseToStudent_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseToStudent_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StartPageId",
                table: "Courses",
                column: "StartPageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseToStudent_CourseId",
                table: "CourseToStudent",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseToStudent_StudentId",
                table: "CourseToStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageToCustomPageContent_CustomPageContentId",
                table: "CustomPageToCustomPageContent",
                column: "CustomPageContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageToCustomPageContent_CustomPageId",
                table: "CustomPageToCustomPageContent",
                column: "CustomPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentGroup_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentGroup_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CourseToStudent");

            migrationBuilder.DropTable(
                name: "CustomPageToCustomPageContent");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CustomPageContent");

            migrationBuilder.DropTable(
                name: "CustomPage");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentGroup_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
