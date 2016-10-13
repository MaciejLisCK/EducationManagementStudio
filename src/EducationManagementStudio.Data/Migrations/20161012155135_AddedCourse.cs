using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: true),
                    NextClassesId = table.Column<int>(nullable: true),
                    ReportId = table.Column<int>(nullable: true),
                    TestId = table.Column<int>(nullable: true),
                    Topic = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_CustomPage_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_CustomPage_NextClassesId",
                        column: x => x.NextClassesId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_CustomPage_ReportId",
                        column: x => x.ReportId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_CustomPage_TestId",
                        column: x => x.TestId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_ExerciseId",
                table: "Class",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_NextClassesId",
                table: "Class",
                column: "NextClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_ReportId",
                table: "Class",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TestId",
                table: "Class",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
