using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests
{
    public class PaginationParams
    {
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10;  

        private const int maxPageSize = 100;
        public int ValidatedPageSize => PageSize > maxPageSize ? maxPageSize : PageSize;
    }
}