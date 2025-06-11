using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Dtos.Requests.User
{
    public class UserLoginReq
    {
        public Guid UserCD { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
