using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUserList()
        {
            return _userRepository.GetUserList();
        }

        public User CreateUser(User user)
        {
            bool isEmailExist = _userRepository.isEmailExist(user.Email);
            if (isEmailExist) { return null; }
            return _userRepository.Create(user);
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public User UpdateUser(User user)
        {
            bool isEmailExist = _userRepository.isEmailExist(user.Email);
            if (isEmailExist) { return null; }
            return _userRepository.Update(user);         
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }
    }
}
