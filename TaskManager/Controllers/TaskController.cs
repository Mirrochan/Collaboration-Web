using Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Contracts;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("ApiTask/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTask([FromBody] AddTaskRequest request)
        {
            TaskModel task = TaskModel.Create(request.Title, request.Description, request.StartData,
                request.DueDate, request.Priority, request.Status, request.UserId);

            var taskId = await _taskService.AddNewTaskAsync(task);
            return Ok(taskId);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromQuery] Guid taskId)
        {
            await _taskService.DeleteTaskAsync(taskId);
            return Ok();
        }
    }
}
