using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class CustomContentFileAddedButtonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomContent");

            migrationBuilder.AddColumn<string>(
                name: "ButtonName",
                table: "CustomContent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonName",
                table: "CustomContent");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomContent",
                nullable: true);
        }
    }
}
