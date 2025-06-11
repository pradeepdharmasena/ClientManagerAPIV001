using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class CustomErrorRes
    {
        public bool IsError { get; set; } = false;
        public string ErrorCode { get; set; } = string.Empty;  
        public string Message { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
