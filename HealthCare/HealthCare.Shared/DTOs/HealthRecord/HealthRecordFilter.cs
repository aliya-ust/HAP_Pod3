using HealthCare.Shared.DTOs;

namespace HealthCare.Shared.DTOs.HealthRecord
{
    public class HealthRecordFilter : PaginationParams
    {
        public DateOnly? VisitDate { get; set; }
    }
} 