namespace And.TimeTracker.Data.Models;

public class TaskModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid TaskGroupId { get; set; }
    
    public TaskGroupModel? TaskGroup { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    public DateTime? AppointmentDate { get; set; }
    
    public TimeSpan ScheduledTime { get; set; }
    
    public TimeSpan SpendTime { get; set; } = TimeSpan.Zero;

    public bool IsCancelled { get; set; } = false;
}