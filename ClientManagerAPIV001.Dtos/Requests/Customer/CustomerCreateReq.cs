using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerCreateReq
    {
        public int CustomerType { get; set; } = 0;
        public int Status { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfileImageURL { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
    }
}
