using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class Notificationtableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Notifications",
                newName: "UserId");
        }
    }
}
