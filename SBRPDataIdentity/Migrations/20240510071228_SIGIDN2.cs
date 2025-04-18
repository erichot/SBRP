using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBRPDataIdentity.Migrations
{
    /// <inheritdoc />
    public partial class SIGIDN2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SIGIDN",
                table: "AspNetUsers",
                column: "SIGIDN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SIGIDN",
                table: "AspNetUsers");
        }
    }
}
