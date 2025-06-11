using ClientManagerAPIV001.DataAccess;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Repositories;

namespace ClientManagerAPIV001.Repository
{
    public class UserRepository(SQLDBContext sQLDBContext) : IUserRepository
    {
        public User? Create(User user)
        {
            var savedEntity = sQLDBContext.Add(user);
            sQLDBContext.SaveChanges();
            return savedEntity.Entity;
        }

        public User? Delete(User user)
        {
            var savedEntity = sQLDBContext.Remove(user);
            sQLDBContext.SaveChanges();
            return savedEntity.Entity;
        }

        public User? GetByCD(Guid cd)
        {
            return sQLDBContext.Users.FirstOrDefault(u => u.UserCD == cd);
        }

        public User? GetByID(int id)
        {
            return sQLDBContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User? Update(User user)
        {
            var savedEntity = sQLDBContext.Update(user);
            sQLDBContext.SaveChanges();
            return savedEntity.Entity;
        }

        public User? GetByEmail(string email)
        {
            return sQLDBContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
