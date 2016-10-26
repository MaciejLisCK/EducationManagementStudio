using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class AddedNewFileResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "CustomContentResponse");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CustomContentResponse",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CustomContentResponse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CustomContentResponse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CustomContentResponse");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "CustomContentResponse",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
