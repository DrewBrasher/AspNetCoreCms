using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreCms.Data.Migrations
{
    public partial class AddSiteIdToPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SitePage_Site_SiteId",
                table: "SitePage");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "SitePage",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SitePage_Site_SiteId",
                table: "SitePage",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SitePage_Site_SiteId",
                table: "SitePage");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "SitePage",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SitePage_Site_SiteId",
                table: "SitePage",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
