using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace Core.Abstractions
{
    public interface IUserService
    {
        Task CreateUser(string firstName, string lastName, string email, string passwordHash);
        Task<UserModel> GetUserById(Guid id);
    }
}
