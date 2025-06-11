using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Repositories
{
    public interface IRoleRepository
    {
        public Role? Create(Role role);
        public Role? Update(Role role);
        public Role? Delete(Role role);
        public Role? GetByID(int id);
        public Role? GetByCD(string cd);
        public List<Role>? GetAll();
    }
}
