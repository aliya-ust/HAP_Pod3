using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthCare.Api.DTOs.Appointment
{
    [AppointmentReportDateValidation]
    public class AppointmentReportFilter
    {
        public DateOnly? FromDate { get; set; }
        public DateOnly? ToDate { get; set; }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AppointmentReportDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var filter = value as AppointmentReportFilter;

            if (filter == null)
                return ValidationResult.Success;

            var today = DateOnly.FromDateTime(DateTime.Today);

            // Check future dates
            if (filter.FromDate.HasValue && filter.FromDate > today)
            {
                return new ValidationResult("FromDate cannot be in the future.");
            }

            if (filter.ToDate.HasValue && filter.ToDate > today)
            {
                return new ValidationResult("ToDate cannot be in the future.");
            }

            // Check range logic
            if (filter.FromDate.HasValue && filter.ToDate.HasValue &&
                filter.FromDate > filter.ToDate)
            {
                return new ValidationResult("FromDate cannot be greater than ToDate.");
            }

            return ValidationResult.Success;
        }
    }
}
