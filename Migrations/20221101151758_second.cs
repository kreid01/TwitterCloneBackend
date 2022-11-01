using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_posterUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_posterUserId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "posterUserId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comment",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CommentBody",
                table: "Comment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentMedia",
                table: "Comment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosterId",
                table: "Comment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Posts_PostId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentBody",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentMedia",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "posterUserId",
                table: "Comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_posterUserId",
                table: "Comment",
                column: "posterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Posts_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_posterUserId",
                table: "Comment",
                column: "posterUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
