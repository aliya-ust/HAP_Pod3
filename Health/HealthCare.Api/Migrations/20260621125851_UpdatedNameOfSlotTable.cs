using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNameOfSlotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots");

            migrationBuilder.RenameTable(
                name: "DoctorAvailableSlots",
                newName: "AvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAvailableSlots_DoctorId",
                table: "AvailableSlots",
                newName: "IX_AvailableSlots_DoctorId");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "AvailableSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSlots_Doctors_DoctorId",
                table: "AvailableSlots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSlots_Doctors_DoctorId",
                table: "AvailableSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "AvailableSlots");

            migrationBuilder.RenameTable(
                name: "AvailableSlots",
                newName: "DoctorAvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableSlots_DoctorId",
                table: "DoctorAvailableSlots",
                newName: "IX_DoctorAvailableSlots_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
