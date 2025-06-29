using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerUpdateReq
    {
        public string CustomerCD { get; set; } = string.Empty;
        public int? CustomerType { get; set; }
        public int? Status { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageURL { get; set; }
    }
}
