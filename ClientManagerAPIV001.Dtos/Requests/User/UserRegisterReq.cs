using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.User
{
    public class UserRegisterReq
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public required string Password { get; set; }

    }
}
