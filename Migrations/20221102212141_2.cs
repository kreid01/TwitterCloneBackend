using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikedPostIds",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostIds",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RetweetedPostIds",
                table: "Users");

            migrationBuilder.AddColumn<List<int>>(
                name: "FollowedBy",
                table: "Posts",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "LikedBy",
                table: "Posts",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowedBy",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LikedBy",
                table: "Posts");

            migrationBuilder.AddColumn<List<int>>(
                name: "LikedPostIds",
                table: "Users",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "PostIds",
                table: "Users",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "RetweetedPostIds",
                table: "Users",
                type: "integer[]",
                nullable: true);
        }
    }
}
