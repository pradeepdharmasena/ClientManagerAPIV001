using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerFieldValueCreateReq
    {
        public Guid CustomerCD { get; set; }
        public required string Name { get; set; }
        public required string Value { get; set; }
    }
}
