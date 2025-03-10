using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace Core.Abstractions
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<Guid> AddNewTaskAsync(TaskModel task);
        Task DeleteTaskAsync(Guid taskId);
        Task UpdateTaskAsync(TaskModel task);
    }
}
