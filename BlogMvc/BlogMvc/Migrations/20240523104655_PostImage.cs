using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogMvc.Migrations
{
    public partial class PostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageFile",
                table: "Posts",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Posts");
        }
    }
}
