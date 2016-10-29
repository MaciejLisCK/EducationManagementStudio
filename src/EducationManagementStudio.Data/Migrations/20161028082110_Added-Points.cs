using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ReceivedPoints",
                table: "CustomContentResponses",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "MaxPoints",
                table: "CustomContent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedPoints",
                table: "CustomContentResponses");

            migrationBuilder.DropColumn(
                name: "MaxPoints",
                table: "CustomContent");
        }
    }
}
