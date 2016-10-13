using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedToCourseCustomContentDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseCustomDescriptionId",
                table: "CustomContent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomContent_CourseCustomDescriptionId",
                table: "CustomContent",
                column: "CourseCustomDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContent_Courses_CourseCustomDescriptionId",
                table: "CustomContent",
                column: "CourseCustomDescriptionId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomContent_Courses_CourseCustomDescriptionId",
                table: "CustomContent");

            migrationBuilder.DropIndex(
                name: "IX_CustomContent_CourseCustomDescriptionId",
                table: "CustomContent");

            migrationBuilder.DropColumn(
                name: "CourseCustomDescriptionId",
                table: "CustomContent");
        }
    }
}
