using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBTarjeta.Migrations
{
    /// <inheritdoc />
    public partial class v101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaExperiacion",
                table: "TarjetaCredit",
                newName: "FechaExpiracion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaExpiracion",
                table: "TarjetaCredit",
                newName: "FechaExperiacion");
        }
    }
}
