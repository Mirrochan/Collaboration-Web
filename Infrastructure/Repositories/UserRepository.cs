using Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerDbContext _context;
        public UserRepository(TaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task CreateNewUser(UserModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> GetUserById(Guid userId)
        {
            UserModel model = await _context.Users.Where(u => u.Id == userId).Select(u => u.Create(u.FirstName, u.LastName, u.Email, u.PasswordHash)).FirstOrDefaultAsync();
            return model;
        }
    }
}
