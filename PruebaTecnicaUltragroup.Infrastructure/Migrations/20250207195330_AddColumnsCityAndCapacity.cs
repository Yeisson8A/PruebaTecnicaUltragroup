using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaUltragroup.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsCityAndCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "HotelRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotel");
        }
    }
}
