using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomContentTextAreaId",
                table: "CustomContentResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomContentResponse_CustomContentTextAreaId",
                table: "CustomContentResponse",
                column: "CustomContentTextAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentTextAreaId",
                table: "CustomContentResponse",
                column: "CustomContentTextAreaId",
                principalTable: "CustomContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentTextAreaId",
                table: "CustomContentResponse");

            migrationBuilder.DropIndex(
                name: "IX_CustomContentResponse_CustomContentTextAreaId",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "CustomContentTextAreaId",
                table: "CustomContentResponse");
        }
    }
}
