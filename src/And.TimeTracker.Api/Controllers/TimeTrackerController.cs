using And.TimeTracker.Data.Context;
using And.TimeTracker.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace And.TimeTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeTrackerController
{
    #region Get

    [HttpGet("task/{id}")]
    public async Task<ActionResult<TaskModel?>> GetTaskById(
        Guid id)
    {
        await using var ctx = new ApplicationContext();
        return await ctx.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    [HttpGet("taskGroup/{id}")]
    public async Task<ActionResult<TaskGroupModel?>> GetTaskGroupById(
        Guid id)
    {
        await using var ctx = new ApplicationContext();
        return await ctx.TaskGroups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    #endregion
    
    #region Add

    [HttpPost("addTask")]
    public async Task AddTask(
        [FromBody] TaskModel dto)
    {
        await using var ctx = new ApplicationContext();
        ctx.Add(dto);
        await ctx.SaveChangesAsync();
    }
    
    [HttpPost("addTaskGroup")]
    public async Task AddTaskGroup(
        [FromBody] TaskGroupModel dto)
    {
        await using var ctx = new ApplicationContext();
        ctx.Add(dto);
        await ctx.SaveChangesAsync();
    }

    #endregion

    #region Update

    [HttpPut("updateTask")]
    public async Task UpdateTask(
        [FromBody] TaskModel dto)
    {
        await using var ctx = new ApplicationContext();
        ctx.Update(dto);
        await ctx.SaveChangesAsync();
    }
    
    [HttpPut("updateTaskGroup")]
    public async Task UpdateTaskGroup(
        [FromBody] TaskGroupModel dto)
    {
        await using var ctx = new ApplicationContext();
        ctx.Update(dto);
        await ctx.SaveChangesAsync();
    }

    #endregion
    
    #region Remove

    [HttpDelete("removeTask")]
    public async Task RemoveTask(
        Guid id)
    {
        await using var ctx = new ApplicationContext();
        var tasks = ctx.Tasks.Where(x => x.Id == id);
        ctx.RemoveRange(tasks);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("removeTaskGroup")]
    public async Task RemoveTaskGroup(
        Guid id)
    {
        await using var ctx = new ApplicationContext();
        var taskGroups = ctx.TaskGroups.Where(x => x.Id == id);
        ctx.RemoveRange(taskGroups);
        await ctx.SaveChangesAsync();
    }

    #endregion
}