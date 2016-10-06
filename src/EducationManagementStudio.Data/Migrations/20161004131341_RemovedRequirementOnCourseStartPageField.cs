using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class RemovedRequirementOnCourseStartPageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "StartPageId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses",
                column: "StartPageId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "StartPageId",
                table: "Courses",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CustomPage_StartPageId",
                table: "Courses",
                column: "StartPageId",
                principalTable: "CustomPage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
