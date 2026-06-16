using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCare.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CancellationReason", "CreatedDate", "DoctorId", "PatientId", "ScheduledDate", "Status", "TimeSlot" },
                values: new object[] { 1, null, new DateTimeOffset(new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, new DateOnly(2026, 6, 20), "Scheduled", "10:00 AM" });

            migrationBuilder.InsertData(
                table: "DoctorAvailableSlots",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "TimeSlot" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "10:00 AM" },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "11:00 AM" }
                });

            migrationBuilder.InsertData(
                table: "DoctorLeaves",
                columns: new[] { "Id", "CreatedDate", "DoctorId", "LeaveDate", "Reason" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, new DateOnly(2026, 6, 25), "Personal Leave" });

            migrationBuilder.InsertData(
                table: "HealthRecords",
                columns: new[] { "RecordId", "AppointmentId", "CreatedDate", "Diagnosis", "DoctorId", "Notes", "PatientId", "Prescription", "VisitDate" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Common Cold", 1, "Drink warm fluids", 1, "Paracetamol 500mg", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAvailableSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoctorAvailableSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorLeaves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HealthRecords",
                keyColumn: "RecordId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1);
        }
    }
}
