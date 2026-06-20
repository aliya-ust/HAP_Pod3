namespace HealthCare.Api.DTOs
{
    public class PaginationParams
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int? PageSize
        {
            get => _pageSize;
            set
            {
                if (value.HasValue)
                {
                    _pageSize = value.Value > MaxPageSize
                        ? MaxPageSize
                        : value.Value;
                }
            }
        }
        public int EffectivePageSize => _pageSize;
    }
}