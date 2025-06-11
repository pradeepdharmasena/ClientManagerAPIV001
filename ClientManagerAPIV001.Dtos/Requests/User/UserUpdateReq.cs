using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Constants;

namespace ClientManagerAPIV001.Dtos.Requests.User
{
    public class UserUpdateReq
    {
        public Guid UserCD { get; set; }
        public int? Status { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? Password { get; set; }
        public List<string>? Roles { get; set; }

    }
}
