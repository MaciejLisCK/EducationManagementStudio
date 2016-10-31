using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedClassToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Courses_CourseId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_CustomPage_ExerciseId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_CustomPage_NextClassesId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_CustomPage_ReportId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_CustomPage_TestId",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Class",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Class",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_CustomPage_ExerciseId",
                table: "Class",
                column: "ExerciseId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_CustomPage_NextClassesId",
                table: "Class",
                column: "NextClassesId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_CustomPage_ReportId",
                table: "Class",
                column: "ReportId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_CustomPage_TestId",
                table: "Class",
                column: "TestId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Class_TestId",
                table: "Class",
                newName: "IX_Classes_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_ReportId",
                table: "Class",
                newName: "IX_Classes_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_NextClassesId",
                table: "Class",
                newName: "IX_Classes_NextClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_ExerciseId",
                table: "Class",
                newName: "IX_Classes_ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                newName: "IX_Classes_CourseId");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_CustomPage_ExerciseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_CustomPage_NextClassesId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_CustomPage_ReportId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_CustomPage_TestId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_CustomPage_ExerciseId",
                table: "Classes",
                column: "ExerciseId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_CustomPage_NextClassesId",
                table: "Classes",
                column: "NextClassesId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_CustomPage_ReportId",
                table: "Classes",
                column: "ReportId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_CustomPage_TestId",
                table: "Classes",
                column: "TestId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Classes_TestId",
                table: "Classes",
                newName: "IX_Class_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ReportId",
                table: "Classes",
                newName: "IX_Class_ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_NextClassesId",
                table: "Classes",
                newName: "IX_Class_NextClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_ExerciseId",
                table: "Classes",
                newName: "IX_Class_ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_CourseId",
                table: "Classes",
                newName: "IX_Class_CourseId");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");
        }
    }
}
