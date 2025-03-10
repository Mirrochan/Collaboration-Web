namespace TaskManager.Contracts
{
   public record UserRequest(string firstName, string lastName, string Email, string passwordHash);
}
