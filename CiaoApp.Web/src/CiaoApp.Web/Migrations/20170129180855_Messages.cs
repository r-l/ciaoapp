using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiaoApp.Web.Migrations
{
    public partial class Messages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Actor_AuthorId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BasePromise_PromiseId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Actor_AuthorId",
                table: "Messages",
                column: "AuthorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_BasePromise_PromiseId",
                table: "Messages",
                column: "PromiseId",
                principalTable: "BasePromise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Messages_PromiseId",
                table: "Messages",
                newName: "IX_Message_PromiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                newName: "IX_Message_AuthorId");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Actor_AuthorId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_BasePromise_PromiseId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Actor_AuthorId",
                table: "Message",
                column: "AuthorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BasePromise_PromiseId",
                table: "Message",
                column: "PromiseId",
                principalTable: "BasePromise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Message_PromiseId",
                table: "Message",
                newName: "IX_Messages_PromiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_AuthorId",
                table: "Message",
                newName: "IX_Messages_AuthorId");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");
        }
    }
}
