using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet("student/{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _studentService.GetStudent(id);
        return Ok(student);
    }
    
    [Authorize(Roles = "admin")]
    [HttpPut("student/{id}")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDTO model)
    {
        await _studentService.UpdateStudent(id, model);
        return Ok();
    } 
    
    [Authorize(Roles = "admin, teacher")]
    [HttpPost("api/marks")]
    public async Task<IActionResult> AddMark([FromBody] AddMarkDTO model)
    {
        await _studentService.AddMark(model);
        return Ok();
    }
}