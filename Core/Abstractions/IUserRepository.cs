using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace Core.Abstractions
{
   public interface IUserRepository
    {
       Task<UserModel> GetUserById(Guid userId);
    }
}
