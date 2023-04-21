using And.TimeTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace And.TimeTracker.Data.Context;

public class ApplicationContext : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; } = null!;
    
    public DbSet<TaskGroupModel> TaskGroups { get; set; } = null!;
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder
            .Entity<TaskModel>(SetPropertyTasks)
            .Entity<TaskGroupModel>(SetPropertyTaskGroups);
    }

    private void SetPropertyTasks(EntityTypeBuilder<TaskModel> entity)
    {
        _ = entity.ToTable("tasks");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("task_name");
        
        _ = entity.Property(e => e.Description)
            .HasMaxLength(150)
            .HasColumnName("task_description");
        
        _ = entity.Property(e => e.CreatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_date_task");
        
        _ = entity.Property(e => e.AppointmentDate)
            .HasColumnType("date")
            .HasColumnName("appointment_date_task");
        
        _ = entity.Property(e => e.ScheduledTime)
            .HasColumnType("interval")
            .HasColumnName("appointment_date_task");
        
        _ = entity.Property(e => e.SpendTime)
            .HasColumnType("interval")
            .HasColumnName("appointment_date_task");
        
        _ = entity.Property(e => e.IsCancelled)
            .HasColumnType("boolean")
            .HasColumnName("appointment_date_task");

        _ = entity.HasOne(t => t.TaskGroup)
            .WithMany(tg => tg.Tasks)
            .HasForeignKey(t => t.TaskGroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_task_group");
    }
    
    private void SetPropertyTaskGroups(EntityTypeBuilder<TaskGroupModel> entity)
    {
        _ = entity.ToTable("task_groups");
        
        _ = entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        _ = entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("task_name");
        
        _ = entity.Property(e => e.Description)
            .HasMaxLength(150)
            .HasColumnName("task_description");
        
        _ = entity.Property(e => e.Color)
            .HasMaxLength(50)
            .HasColumnName("task_description");
    }
}