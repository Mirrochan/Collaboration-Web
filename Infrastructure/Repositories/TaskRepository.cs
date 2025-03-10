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
    public class TaskRepository : ITaskRepository
    {
        
        private readonly TaskManagerDbContext _context;

        public TaskRepository(TaskManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddNewTaskAsync(TaskModel task)
        {  task.User= await _context.Users.FirstOrDefaultAsync(u => u.Id == task.UserId);
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            await _context.Tasks.Where(t => t.Id == taskId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
          var tasks = await _context.Tasks
                .ToListAsync();
            return tasks;
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            await _context.Tasks.Where(t => t.Id == task.Id).ExecuteUpdateAsync(
          s=>s.
          SetProperty(t => t.Status, t=>task.Status));
            await _context.SaveChangesAsync();
        }
    }
}
