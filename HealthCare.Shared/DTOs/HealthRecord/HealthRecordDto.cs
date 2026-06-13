using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Shared.DTOs.HealthRecord
{
    [ExcludeFromCodeCoverage]
    public class HealthRecordDto
    {
        public int RecordId { get; set; }
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Patient ID is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Diagnosis is required")]
        public string Diagnosis { get; set; }

        [Required(ErrorMessage = "Prescription is required")]
        public string Prescription { get; set; }

        public string Notes { get; set; }

        public DateTime VisitDate { get; set; }
    }
}