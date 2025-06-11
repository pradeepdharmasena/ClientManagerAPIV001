using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.Customer
{
    public class CustomerUpdateReq
    {
        public Guid CustomerCD { get; set; }
        public int? CustomerType { get; set; }
        public int? Status { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageURL { get; set; }
    }
}
