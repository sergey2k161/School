using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
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

    [HttpPost("student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentDTO model)
    {
        var result = await _authService.RegisterStudent(model);

        return Ok(result);
    }
    
    [HttpPost("teacher")]
    public async Task<IActionResult> RegisterTeacher([FromBody] RegisterTeacherDTO model)
    {
        var result = await _authService.RegisterTeacher(model);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Проверяем, существует ли пользователь и правильны ли учетные данные
        var result = await _authService.Login(model);

        if (!result.IsSuccess)
        {
            return Unauthorized(new { message = string.Join(", ", result.Errors) });
        }

        // Генерируем токен, передавая пользователя
        var token = GenerateJwtToken(result.User);

        // Возвращаем токен клиенту
        return Ok(new { token });
    }

    [HttpPut("student/{id}")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDTO model)
    {
        await _authService.UpdateStudent(id, model);
        return Ok();
    } 
    [HttpPut("teaher/{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherDTO model)
    {
        await _authService.UpdateTeacher(id, model);
        return Ok();
    }
    private string GenerateJwtToken(CommonUser user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Convert Id to string
        };
    
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    
}