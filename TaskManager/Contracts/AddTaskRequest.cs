namespace TaskManager.Contracts
{  
    public record AddTaskRequest(
     string Title,
     string Description,
     DateTime? StartData ,
     DateTime? DueDate ,
     string Priority,
     string Status,
     Guid UserId);
}
