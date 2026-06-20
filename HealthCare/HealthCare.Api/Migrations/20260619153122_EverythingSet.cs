using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class everythingset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId1",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId1",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId1",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "DoctorAvailableSlots",
                newName: "AvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAvailableSlots_DoctorId",
                table: "AvailableSlots",
                newName: "IX_AvailableSlots_DoctorId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AvailableSlots",
                newName: "DoctorAvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableSlots_DoctorId",
                table: "DoctorAvailableSlots",
                newName: "IX_DoctorAvailableSlots_DoctorId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId1",
                table: "Patients",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId1",
                table: "Doctors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId1",
                table: "Doctors",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId1",
                table: "Patients",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
