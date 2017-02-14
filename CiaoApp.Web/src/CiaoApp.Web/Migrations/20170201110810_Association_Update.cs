using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiaoApp.Web.Migrations
{
    public partial class Association_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_State_TargetStateId",
                table: "Association");

            migrationBuilder.DropIndex(
                name: "IX_Association_TargetStateId",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "TargetStateId",
                table: "Association");

            migrationBuilder.AddColumn<int>(
                name: "TargetState",
                table: "Association",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetState",
                table: "Association");

            migrationBuilder.AddColumn<int>(
                name: "TargetStateId",
                table: "Association",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Association_TargetStateId",
                table: "Association",
                column: "TargetStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_State_TargetStateId",
                table: "Association",
                column: "TargetStateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
