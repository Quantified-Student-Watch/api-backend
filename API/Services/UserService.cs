using System;
using System.Threading.Tasks;
using API.Data.Repository;
using API.Models;

namespace API.Services
{
    public interface IUserService
    {
        public User CreateUser(string name, string email);
        public Task<User> GetUserByIdAsync(Guid id);
    }
    
    
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User CreateUser(string name, string email)
        {
            User user = _userRepository.CreatUser(name, email);
            if (user != null)
            {
                return user;
            }

            throw new Exception("User could not be created");
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User user = await _userRepository.GetUserAsync(id);

            if (user != null)
            {
                return user;
            }

            throw new Exception("User could not be found");
        }
    }
}