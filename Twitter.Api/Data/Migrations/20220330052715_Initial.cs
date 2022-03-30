namespace Twitter_backend.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// .
    /// </summary>
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tweet",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    DateTweet = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tweet_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                schema: "public",
                columns: table => new
                {
                    FollowersId = table.Column<int>(type: "integer", nullable: false),
                    FollowingId = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_UserUser_User_FollowersId",
                        column: x => x.FollowersId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_User_FollowingId",
                        column: x => x.FollowingId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TextComment = table.Column<string>(type: "text", nullable: true),
                    DateComment = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    TweetId = table.Column<int>(type: "integer", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Tweet_TweetId",
                        column: x => x.TweetId,
                        principalSchema: "public",
                        principalTable: "Tweet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TweetId",
                schema: "public",
                table: "Comment",
                column: "TweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "public",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweet_UserId",
                schema: "public",
                table: "Tweet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingId",
                schema: "public",
                table: "UserUser",
                column: "FollowingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "public");

            migrationBuilder.DropTable(
                name: "UserUser",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tweet",
                schema: "public");

            migrationBuilder.DropTable(
                name: "User",
                schema: "public");
        }
    }
}
