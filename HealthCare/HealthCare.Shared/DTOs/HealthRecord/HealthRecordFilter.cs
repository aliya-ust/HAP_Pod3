namespace HealthCare.Api.DTOs.HealthRecord
{
    public class HealthRecordFilter : PaginationParams
    {
        public DateOnly? VisitDate { get; set; }
    }
} 