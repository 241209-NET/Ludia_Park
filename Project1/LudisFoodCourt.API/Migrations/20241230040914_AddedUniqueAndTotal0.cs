using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LudisFoodCourt.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueAndTotal0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Diners_Name",
                table: "Diners",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Diners_Name",
                table: "Diners");
        }
    }
}
