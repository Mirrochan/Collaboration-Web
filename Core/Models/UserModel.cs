namespace TaskManager.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
        public ICollection<GroupModel> Groups { get; set; } = new List<GroupModel>();
    }
}
