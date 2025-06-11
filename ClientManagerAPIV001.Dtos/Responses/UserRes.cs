using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Constants;

namespace ClientManagerAPIV001.Dtos.Responses
{
    public class UserRes
    {
        public Guid UserCD { get; set; } 
        public int Status { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImageURL { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [RoleTypes.ADMIN];
        public string? RefreshToken { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
