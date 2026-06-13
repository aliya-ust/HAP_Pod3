using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Shared.DTOs.Appointment
{
    [ExcludeFromCodeCoverage]
    public class CreateAppointmentDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [Required]
        public string TimeSlot { get; set; }
    }
}