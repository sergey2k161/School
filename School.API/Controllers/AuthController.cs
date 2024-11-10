using Microsoft.AspNetCore.Mvc;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.DTO;

namespace School.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    [HttpPost("register/student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDTO model)
    {
        var classid = model.ClassId;
        var result = await _authService.RegisterStudent(model);

        return Ok(result);
    }
}