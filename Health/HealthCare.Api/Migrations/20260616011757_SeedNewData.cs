using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSlots_Doctors_DoctorId",
                table: "AvailableSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLeaves_Doctors_DoctorId",
                table: "DoctorLeaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Appointments_AppointmentId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Doctors_DoctorId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Patients_PatientId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_PatientId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "AvailableSlots",
                newName: "DoctorAvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableSlots_DoctorId",
                table: "DoctorAvailableSlots",
                newName: "IX_DoctorAvailableSlots_DoctorId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Appointments",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "DoctorAvailableSlots",
                columns: new[] { "Id", "DoctorId", "TimeSlot" },
                values: new object[] { 2, 1, "11:00 AM" });

            migrationBuilder.UpdateData(
                table: "DoctorLeaves",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: "Personal Leave");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                columns: new[] { "ConsultationFee", "FullName", "UserId", "YearsOfExperience" },
                values: new object[] { 800m, "Dr. Anil Mehta", 1, 12 });

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "RecordId",
                keyValue: 1,
                columns: new[] { "Diagnosis", "Notes", "Prescription", "VisitDate" },
                values: new object[] { "Common Cold", "Drink warm fluids", "Paracetamol 500mg", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "FullName" },
                values: new object[] { new DateOnly(1990, 5, 12), "Arjun Raj" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "PasswordHash", "Role" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "doctor1@test.com", "$2a$12$3QNBAyYA6NKZfqyX9v14Eexx1qywJJPm1rXPK8ow/fWq6jpnk.1FS", "Doctor" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Email", "PasswordHash" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "patient1@test.com", "$2a$12$3QNBAyYA6NKZfqyX9v14Eexx1qywJJPm1rXPK8ow/fWq6jpnk.1FS" });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_Patient_VisitDate",
                table: "HealthRecords",
                columns: new[] { "PatientId", "VisitDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Doctor_Date",
                table: "Appointments",
                columns: new[] { "DoctorId", "ScheduledDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Patient_Date",
                table: "Appointments",
                columns: new[] { "PatientId", "ScheduledDate" });

            migrationBuilder.CreateIndex(
                name: "UQ_Appointments_Doctor_Date_Slot",
                table: "Appointments",
                columns: new[] { "DoctorId", "ScheduledDate", "TimeSlot" },
                unique: true,
                filter: "[Status] != 'Cancelled'");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLeaves_Doctors_DoctorId",
                table: "DoctorLeaves",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Appointments_AppointmentId",
                table: "HealthRecords",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Doctors_DoctorId",
                table: "HealthRecords",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Patients_PatientId",
                table: "HealthRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailableSlots_Doctors_DoctorId",
                table: "DoctorAvailableSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLeaves_Doctors_DoctorId",
                table: "DoctorLeaves");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Appointments_AppointmentId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Doctors_DoctorId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Patients_PatientId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_Patient_VisitDate",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Doctor_Date",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Patient_Date",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "UQ_Appointments_Doctor_Date_Slot",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorAvailableSlots",
                table: "DoctorAvailableSlots");

            migrationBuilder.DeleteData(
                table: "DoctorAvailableSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "DoctorAvailableSlots",
                newName: "AvailableSlots");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAvailableSlots_DoctorId",
                table: "AvailableSlots",
                newName: "IX_AvailableSlots_DoctorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "HealthRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Appointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableSlots",
                table: "AvailableSlots",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DoctorLeaves",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: "Personal");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                columns: new[] { "ConsultationFee", "CreatedDate", "FullName", "UserId", "YearsOfExperience" },
                values: new object[] { 500m, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "John Doctor", 3, 10 });

            migrationBuilder.UpdateData(
                table: "HealthRecords",
                keyColumn: "RecordId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Diagnosis", "Notes", "Prescription", "VisitDate" },
                values: new object[] { new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fever", "Take rest", "Paracetamol", new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "Email", "FullName" },
                values: new object[] { new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateOnly(1995, 5, 10), "patient@test.com", "Ravi Kumar" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "PasswordHash", "Role" },
                values: new object[] { "admin@example.com", "hashedpassword456", "Admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "patient1@example.com", "hashedpassword123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "Role" },
                values: new object[] { 3, "doctor1@example.com", "hashedpassword456", null, null, "Doctor" });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_PatientId",
                table: "HealthRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSlots_Doctors_DoctorId",
                table: "AvailableSlots",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLeaves_Doctors_DoctorId",
                table: "DoctorLeaves",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Users_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Appointments_AppointmentId",
                table: "HealthRecords",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Doctors_DoctorId",
                table: "HealthRecords",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Patients_PatientId",
                table: "HealthRecords",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Users_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
