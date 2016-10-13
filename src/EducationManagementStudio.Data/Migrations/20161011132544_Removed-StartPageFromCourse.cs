using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class RemovedStartPageFromCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StartPageId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartPageId",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartPageId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StartPageId",
                table: "Courses",
                column: "StartPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses",
                column: "StartPageId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
