using System.ComponentModel.DataAnnotations;

namespace HealthAppWeb.Models.ViewModels
{
    public class CancelAppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string TimeSlot { get; set; }

        [Required(ErrorMessage = "Please provide a reason for cancellation.")]
        [StringLength(500)]
        public string Reason { get; set; }
    }
}