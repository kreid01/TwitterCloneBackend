using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    public partial class chats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User1 = table.Column<int>(type: "integer", nullable: false),
                    User2 = table.Column<int>(type: "integer", nullable: false),
                    User1Name = table.Column<string>(type: "text", nullable: false),
                    User2Name = table.Column<string>(type: "text", nullable: false),
                    User1At = table.Column<string>(type: "text", nullable: false),
                    User2At = table.Column<string>(type: "text", nullable: false),
                    User1Img = table.Column<string>(type: "text", nullable: false),
                    User2Img = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    SenderName = table.Column<string>(type: "text", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });
        }

          

        protected override void Down(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.DropTable(
                name: "Messages");


        }
    }
}
