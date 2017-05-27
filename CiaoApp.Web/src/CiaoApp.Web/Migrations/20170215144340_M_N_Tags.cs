using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CiaoApp.Web.Migrations
{
    public partial class M_N_Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_BasePromise_BasePromiseId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_BasePromiseId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "BasePromiseId",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "TagAssociation",
                columns: table => new
                {
                    BasePromiseId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagAssociation", x => new { x.BasePromiseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagAssociation_BasePromise_BasePromiseId",
                        column: x => x.BasePromiseId,
                        principalTable: "BasePromise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagAssociation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagAssociation_BasePromiseId",
                table: "TagAssociation",
                column: "BasePromiseId");

            migrationBuilder.CreateIndex(
                name: "IX_TagAssociation_TagId",
                table: "TagAssociation",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagAssociation");

            migrationBuilder.AddColumn<int>(
                name: "BasePromiseId",
                table: "Tag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BasePromiseId",
                table: "Tag",
                column: "BasePromiseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_BasePromise_BasePromiseId",
                table: "Tag",
                column: "BasePromiseId",
                principalTable: "BasePromise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
