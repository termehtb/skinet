using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Specifcation
{
    public class ProducSpectPrams
    {
        private int MaximumPageSize = 50;
        public int PageIndex {get; set;} = 1;
        private int _pageSize = 6;
        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > MaximumPageSize)? MaximumPageSize: value;
        }
        public int? BrandId { get; set; }
        
        public int? TypeId { get; set; }
        public string? Sort { get; set; }
    }
}