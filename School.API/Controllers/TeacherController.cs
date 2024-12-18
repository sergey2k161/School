using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    
    
    [HttpGet("teacher/{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
        var teacher = await _teacherService.GetTeacher(id);
        return Ok(teacher);
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("teacher/{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherDTO model)
    {
        await _teacherService.UpdateTeacher(id, model);
        return Ok();
    }
    
    // [Authorize(Roles = "admin, student")]
    // [HttpPost("api/marks")]
    // public async Task<IActionResult> AddMark([FromBody] AddMarkDTO model)
    // {
    //     await _teacherService.AddMark(model);
    //     return Ok();
    // }
}