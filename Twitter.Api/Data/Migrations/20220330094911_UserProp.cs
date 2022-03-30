namespace Twitter_backend.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    /// <summary>
    /// .
    /// </summary>
    public partial class UserProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserUser",
                schema: "public",
                newName: "UserUser");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "public",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Tweet",
                schema: "public",
                newName: "Tweet");

            migrationBuilder.RenameTable(
                name: "Comment",
                schema: "public",
                newName: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "UserUser",
                newName: "UserUser",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Tweet",
                newName: "Tweet",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comment",
                newSchema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "public",
                table: "User",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
        }
    }
}
