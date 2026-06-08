using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HealthAppWeb.Models.ViewModels
{
    public class AppointmentBookingViewModel
    {
        [Required]
        [Display(Name = "Doctor")]
        public int SelectedDoctorId { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime SelectedDate { get; set; }

        [Required]
        [Display(Name = "Time Slot")]
        public string SelectedSlot { get; set; }

        public List<SelectListItem> Doctors { get; set; }
        public List<string> AvailableSlots { get; set; }

        public AppointmentBookingViewModel()
        {
            Doctors = new List<SelectListItem>();
            AvailableSlots = new List<string>();
            SelectedDate = DateTime.Today;
        }
    }
}