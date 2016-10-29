using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class CustomPageAccessibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomPageAccessibilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomPageId = table.Column<int>(nullable: false),
                    EndAccessDateTime = table.Column<DateTime>(nullable: false),
                    StartAccessDateTime = table.Column<DateTime>(nullable: false),
                    StudentGroupId = table.Column<int>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPageAccessibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomPageAccessibilities_CustomPage_CustomPageId",
                        column: x => x.CustomPageId,
                        principalTable: "CustomPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomPageAccessibilities_StudentGroup_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomPageAccessibilities_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageAccessibilities_CustomPageId",
                table: "CustomPageAccessibilities",
                column: "CustomPageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageAccessibilities_StudentGroupId",
                table: "CustomPageAccessibilities",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPageAccessibilities_StudentId",
                table: "CustomPageAccessibilities",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomPageAccessibilities");
        }
    }
}
