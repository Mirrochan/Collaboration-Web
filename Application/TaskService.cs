using Core.Abstractions;
using TaskManager.Models;

namespace Application
{
    public class TaskService : ITaskService
    {   
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Guid> AddNewTaskAsync(TaskModel task)
        {  
           await _taskRepository.AddNewTaskAsync(task);
            return task.Id;
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            await _taskRepository.DeleteTaskAsync(taskId);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
         var tasks=  await _taskRepository.GetAllTasksAsync();
            return tasks;
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
           await _taskRepository.UpdateTaskAsync(task);
        }
    }
}
