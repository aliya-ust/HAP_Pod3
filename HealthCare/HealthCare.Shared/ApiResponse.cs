using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Shared
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
} 