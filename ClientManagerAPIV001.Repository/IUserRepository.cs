using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Models;


namespace ClientManagerAPIV001.Repositories
{
    public interface IUserRepository
    {
        public User? Create(User user);
        public User? Update(User user);
        public User? Delete(User user);
        public User? GetByID(int id);
        public User? GetByCD(Guid cd);
        public User? GetByEmail(string email);

    }
}
