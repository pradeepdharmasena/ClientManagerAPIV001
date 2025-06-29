using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class CustomerRes
    {
        public string CustomerCD { get; set; } = string.Empty;
        public int CustomerType { get; set; } = 0;
        public int Status { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImageURL { get; set; } = string.Empty;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public List<CustomerFieldRes> Fields { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
    }
}
