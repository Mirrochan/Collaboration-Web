namespace TaskManager.Models
{
    public class GroupModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

    }
}
