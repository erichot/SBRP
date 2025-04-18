using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataIdentity.Migrations
{
    /// <inheritdoc />
    public partial class SIGIDN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "AspNetUsers",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "100, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<short>(
                name: "SIGIDN",
                table: "AspNetUsers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LoginId",
                table: "AspNetUsers",
                column: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LoginId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SIGIDN",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "AspNetUsers",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "100, 1");
        }
    }
}
