using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserList();
        User Create(User user);
        User GetById(int userId);
        User Update(User user);
        void Delete(int userId);
        bool isEmailExist(string email);
    }
    public class UserRepository : IUserRepository
    {
        private readonly OnlineLearningContext _context;

        public UserRepository(OnlineLearningContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public bool isEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetUserList()
        {
            return _context.Users.ToList();
        }

        public User Update(User user)
        {
         
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;

        }

        
    }
}
