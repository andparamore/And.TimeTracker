namespace And.TimeTracker.Data.Models;

public class TaskGroupModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string Color { get; set; } = string.Empty;

    public IEnumerable<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}