using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagerAPIV001.Models
{
    public class Role
    {
        public long RoleID { get; set; }
        public required string RoleCD { get; set; }
        public required string Description { get; set; }

    }
}
