using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Constants;

namespace ClientManagerAPIV001.Models
{
    public class User
    {
        public long UserId { get; set; } = 0;
        public Guid UserCD { get; set; } = Guid.NewGuid();
        public int Status { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfileImageURL { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [RoleTypes.ADMIN];
        public string? RefreshToken { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

    }
}
