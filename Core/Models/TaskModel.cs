

using System.Diagnostics.CodeAnalysis;

namespace TaskManager.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartData { get; set; } = null;
        public DateTime? DueDate { get; set; } = null;
        public string Priority { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public UserModel? User { get; set; }  

        public static TaskModel Create(string title, string description, DateTime? startData, DateTime? dueDate, string priority, string status, Guid userId)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
            if (description == null)
                throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrWhiteSpace(priority))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(priority));
           if(string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(status));
            
            return new TaskModel
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                StartData = startData,
                DueDate = dueDate,
                Priority = priority,
                Status = status,
                UserId = userId
            };
        }
    }
}
