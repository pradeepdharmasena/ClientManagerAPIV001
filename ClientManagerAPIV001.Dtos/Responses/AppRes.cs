using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class AppRes<T>
    {
        public T? Results { get; set; }
        public CustomErrorRes? Error { get; set; }
        public PaginationInfo? PaginationInfo { get; set; }

    }
}
