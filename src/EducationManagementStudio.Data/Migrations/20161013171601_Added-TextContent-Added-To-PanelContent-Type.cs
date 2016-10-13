using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedTextContentAddedToPanelContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PanelType",
                table: "CustomContent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PanelType",
                table: "CustomContent");
        }
    }
}
