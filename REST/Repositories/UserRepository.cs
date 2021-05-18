using System.Collections.Generic;
using System.Linq;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.REST.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.CommandUser.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.CommandUser.FirstOrDefault(user => user.IdUser == id);
        }

        public void PostUser(User user)
        {
            _context.CommandUser.Add(user);
            SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.CommandUser.Update(user);
            SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _context.CommandUser.Remove(GetUserById(id));
            SaveChanges();
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }

    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public void PostUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        void SaveChanges();
    }
}