using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreCms.Data.Migrations
{
    public partial class AddTitleAndThemeToSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Site",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Site",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Site");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Site");
        }
    }
}
