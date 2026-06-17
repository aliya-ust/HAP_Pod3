using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "PasswordHash", "RefreshToken", "RefreshTokenExpiry", "Role" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "hashedpassword456", null, null, "Admin" },
                    { 2, "patient1@example.com", "hashedpassword123", null, null, "Patient" },
                    { 3, "doctor1@example.com", "hashedpassword456", null, null, "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "ConsultationFee", "CreatedDate", "FullName", "IsActive", "Specialisation", "UserId", "YearsOfExperience" },
                values: new object[] { 1, 500m, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "John Doctor", true, "Cardiology", 3, 10 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "CreatedDate", "DateOfBirth", "Email", "FullName", "Gender", "InsuranceId", "IsActive", "PhoneNumber", "UserId" },
                values: new object[] { 1, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateOnly(1995, 5, 10), "patient@test.com", "Ravi Kumar", "Male", "INS200", true, "9876543210", 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CancellationReason", "CreatedDate", "DoctorId", "PatientId", "ScheduledDate", "Status", "TimeSlot" },
                values: new object[] { 1, null, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateOnly(2026, 6, 20), "Scheduled", "10:00 AM" });

            migrationBuilder.InsertData(
                table: "AvailableSlots",
                columns: new[] { "Id", "DoctorId", "TimeSlot" },
                values: new object[] { 1, 1, "10:00 AM" });

            migrationBuilder.InsertData(
                table: "DoctorLeaves",
                columns: new[] { "Id", "DoctorId", "LeaveDate", "Reason" },
                values: new object[] { 1, 1, new DateOnly(2026, 6, 25), "Personal" });

            migrationBuilder.InsertData(
                table: "HealthRecords",
                columns: new[] { "RecordId", "AppointmentId", "CreatedDate", "Diagnosis", "DoctorId", "Notes", "PatientId", "Prescription", "VisitDate" },
                values: new object[] { 1, 1, new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), "Fever", 1, "Take rest", 1, "Paracetamol", new DateTime(2026, 6, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AvailableSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoctorLeaves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "RecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
