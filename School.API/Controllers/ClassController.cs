using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly IClassService ClassService;
    
    public ClassController(IClassService classService)
    {
        ClassService = classService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateClassDTO model)
    {
        var result = await ClassService.CreateClass(model);

        return Ok(result);
    }
}