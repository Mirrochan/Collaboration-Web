using Core.Abstractions;
using Infrastructure;
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
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUserRepository userRepository, 
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider) {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        
        public async Task CreateUser(string firstName, string lastName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);
            UserModel model = new UserModel().Create( firstName, lastName, email, hashedPassword);
            await _userRepository.CreateNewUser(model);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
          UserModel user =  await _userRepository.GetUserById(id);
            return user;
        }

        public async Task<string> Login (string email, string password)
        {
            UserModel user = await _userRepository.GetUserByEmail(email);
            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if(result == false)
            {
                throw new Exception("Failed ti login");
            }
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }


   
    }
}
