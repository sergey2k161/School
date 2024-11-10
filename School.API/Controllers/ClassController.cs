using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassService _сlassService;
    
    public ClassController(IClassService classService)
    {
        _сlassService = classService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateClassDTO model)
    {
        var result = await _сlassService.CreateClass(model);

        return Ok(result);
    }
    
    [HttpPost("AddStudentToClass")]
    public async Task<IActionResult> AddStudentToClass([FromBody] AddStudentToClassDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _сlassService.AddStudentToClass(model.ClassId, model.StudentId);
            
        if (result.IsSuccess)
        {
            return Ok(new { message = "Student successfully added to the class" });
        }

        return BadRequest(new { errors = result.Errors });
    }
    
    [HttpPut("UpdateMainTeacher")]
    public async Task<IActionResult> UpdateMainTeacher([FromBody] UpdateMainTeacherDto model)
    {
        await _сlassService.UpdateMainTeacher(model.ClassId, model.TeacherId);
        return Ok();
    }
    
    [HttpGet("ClassByid")]
    public async Task<IActionResult> GetClassById(int id)
    {
        var result = await _сlassService.GetClassById(id);
        return Ok(result);
    }
    
    [HttpGet("AllClasses")]
    public async Task<IActionResult> GetAllClasses()
    {
        var result = await _сlassService.GetAllClasses();
        return Ok(result);
    }
    
}