using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsBooked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "AvailableSlots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "AvailableSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
