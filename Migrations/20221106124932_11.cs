using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.AddColumn<List<int>>(
                name: "Followers",
                table: "Users",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "Following",
                table: "Users",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Followers",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Following",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAt = table.Column<string>(type: "text", nullable: false),
                    UserId1 = table.Column<int>(type: "integer", nullable: false),
                    UserImg = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Followers_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAt = table.Column<string>(type: "text", nullable: false),
                    UserId1 = table.Column<int>(type: "integer", nullable: false),
                    UserImg = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Following_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Followers_UserId1",
                table: "Followers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Following_UserId1",
                table: "Following",
                column: "UserId1");
        }
    }
}
