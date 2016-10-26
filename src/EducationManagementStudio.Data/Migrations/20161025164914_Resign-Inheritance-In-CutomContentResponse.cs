using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationManagementStudio.Data.Migrations
{
    public partial class ResignInheritanceInCutomContentResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentId",
                table: "CustomContentResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponse_AspNetUsers_StudentId",
                table: "CustomContentResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentTextAreaId",
                table: "CustomContentResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomContentResponse",
                table: "CustomContentResponse");

            migrationBuilder.DropIndex(
                name: "IX_CustomContentResponse_CustomContentTextAreaId",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "CustomContentTextAreaId",
                table: "CustomContentResponse");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "CustomContentResponse");

            migrationBuilder.AddColumn<string>(
                name: "TextAreaResponse",
                table: "CustomContentResponse",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomContentResponses",
                table: "CustomContentResponse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponses_CustomContent_CustomContentId",
                table: "CustomContentResponse",
                column: "CustomContentId",
                principalTable: "CustomContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponses_AspNetUsers_StudentId",
                table: "CustomContentResponse",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_CustomContentResponse_StudentId",
                table: "CustomContentResponse",
                newName: "IX_CustomContentResponses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomContentResponse_CustomContentId",
                table: "CustomContentResponse",
                newName: "IX_CustomContentResponses_CustomContentId");

            migrationBuilder.RenameTable(
                name: "CustomContentResponse",
                newName: "CustomContentResponses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponses_CustomContent_CustomContentId",
                table: "CustomContentResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomContentResponses_AspNetUsers_StudentId",
                table: "CustomContentResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomContentResponses",
                table: "CustomContentResponses");

            migrationBuilder.DropColumn(
                name: "TextAreaResponse",
                table: "CustomContentResponses");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CustomContentResponses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CustomContentResponses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomContentTextAreaId",
                table: "CustomContentResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "CustomContentResponses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomContentResponse",
                table: "CustomContentResponses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContentResponse_CustomContentTextAreaId",
                table: "CustomContentResponses",
                column: "CustomContentTextAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentId",
                table: "CustomContentResponses",
                column: "CustomContentId",
                principalTable: "CustomContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponse_AspNetUsers_StudentId",
                table: "CustomContentResponses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomContentResponse_CustomContent_CustomContentTextAreaId",
                table: "CustomContentResponses",
                column: "CustomContentTextAreaId",
                principalTable: "CustomContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_CustomContentResponses_StudentId",
                table: "CustomContentResponses",
                newName: "IX_CustomContentResponse_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomContentResponses_CustomContentId",
                table: "CustomContentResponses",
                newName: "IX_CustomContentResponse_CustomContentId");

            migrationBuilder.RenameTable(
                name: "CustomContentResponses",
                newName: "CustomContentResponse");
        }
    }
}
