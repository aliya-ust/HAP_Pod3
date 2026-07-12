namespace HealthCare.Api.Options
{
    public class GarnetOptions
    {
        public string ConnectionString { get; set; } = "localhots:6379";

        public string InstanceName { get; set; } = "HealthCareApi:";
    }
}
