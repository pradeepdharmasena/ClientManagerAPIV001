using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerFieldValueCreateReq
    {
        public string CustomerCD { get; set; } = string.Empty;
        public required int FieldID { get; set; }
        public required string Value { get; set; }
    }
}
