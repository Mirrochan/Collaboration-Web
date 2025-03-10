using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        
        public async Task CreateUser(string firstName, string lastName, string email, string password)
        {
            
            UserModel model = new UserModel().Create( firstName, lastName, email, password);
            await _userRepository.CreateNewUser(model);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
          UserModel user =  await _userRepository.GetUserById(id);
            return user;
        }
    }
}
