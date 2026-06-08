using System;
using System.Collections.Generic;

namespace HealthAppWeb.Models.Helpers
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling(TotalCount / (double)PageSize); }
        }

        public bool HasPrev
        {
            get { return PageNumber > 1; }
        }

        public bool HasNext
        {
            get { return PageNumber < TotalPages; }
        }

        public PagedResult()
        {
            Items = new List<T>();
        }
    }
}