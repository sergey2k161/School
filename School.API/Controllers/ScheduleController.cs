using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleService _scheduleService;

    public ScheduleController(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    [HttpGet("GetScheduleByClass/{id}")]
    public async Task<IActionResult> GetScheduleByClass(int id)
    {
        var schedules = await _scheduleService.GetScheduleByClassAsync(id);
        return Ok(schedules);
    }
    
    [HttpGet("GetScheduleByTeacher/{id}")]
    public async Task<IActionResult> GetScheduleByTeacher(int id)
    {
        var schedules = await _scheduleService.GetScheduleByTeacherAsync(id);
        return Ok(schedules);
    }
    
    [HttpGet("GetScheduleByCabinet/{id}")]
    public async Task<IActionResult> GetScheduleByCabinet(int id)
    {
        var schedules = await _scheduleService.GetScheduleByCabinetAsync(id);
        return Ok(schedules);
    }
    
    [HttpGet("GetSchedulesByStudent/{id}")]
    public async Task<IActionResult> GetSchedulesByStudent(int id)
    {
        var schedules = await _scheduleService.GetSchedulesByStudentAsync(id);
        return Ok(schedules);
    }
    
    [HttpGet("GetSchedule/{id}")]
    public async Task<IActionResult> GetSchedule(int id)
    {
        var schedule = await _scheduleService.GetScheduleAsync(id);
        return Ok(schedule);
    }
    
    [HttpGet("GetAllSchedules")]
    public async Task<IActionResult> GetAllSchedules()
    {
        var schedules = await _scheduleService.GetAllSchedulesAsync();
        return Ok(schedules);
    }

    [Authorize(Roles = "admin")]
    [HttpPost("AddSchedule")]
    public async Task<IActionResult> AddSchedule(ScheduleDto schedule)
    {
        await _scheduleService.AddScheduleAsync(schedule);
        return Ok();
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("UpdateSchedule")]
    public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleGetDto schedule, int id)
    {
        await _scheduleService.UpdateScheduleAsync(id, schedule);
        return Ok();
    }
    
    [Authorize(Roles = "admin")]
    [HttpDelete("RemoveSchedule/{id}")]
    public async Task<IActionResult> RemoveSchedule(int id)
    {
        await _scheduleService.RemoveScheduleAsync(id);
        return Ok();
    }
}