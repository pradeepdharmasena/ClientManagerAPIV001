using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Constants;

namespace ClientManagerAPIV001.Models
{
    public class Customer
    {
        public long CustomerId { get; set; } = 0;
        public string CustomerCD { get; set; } = string.Empty;
        public int CustomerType { get; set; } = 0;
        public int Status { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImageURL { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
