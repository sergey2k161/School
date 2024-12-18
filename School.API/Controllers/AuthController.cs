using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Extension;
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
    
    [Authorize(Roles = "admin")]
    [HttpPost("students")]
    public async Task<IActionResult> RegisterStudents([FromBody] RegisterStudentsDTO model)
    {
        var result = await _authService.RegisterStudents(model);

        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result.Errors); 
    }

    [Authorize(Roles = "admin")]
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

        // Устанавливаем токен в куки
        var cookieOptions = new CookieOptions
        {
            HttpOnly = false, // Обеспечивает недоступность куки через JavaScript
            Secure = false,   // Использовать только через HTTPS
            SameSite = SameSiteMode.Strict, // Защита от CSRF
            Expires = DateTime.UtcNow.AddMinutes(60) // Устанавливаем время жизни куки
        };
        Response.Cookies.Append("AuthToken", token, cookieOptions);

        // Возвращаем успешный результат
        return Ok(new { token, message = "Login successful" });
    }

    
    private string GenerateJwtToken(CommonUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // Если у пользователя есть связь с Student, добавляем роль 'student' в токен
        if (user.StudentId.HasValue)
        {
            claims.Add(new Claim(ClaimTypes.Role, "student"));
            claims.Add(new Claim("studentId", user.StudentId.ToString())); // Добавляем ID студента
        }
        // Если у пользователя есть связь с Teacher, добавляем роль 'teacher' в токен
        else if (user.TeacherId.HasValue)
        {
            claims.Add(new Claim(ClaimTypes.Role, "teacher"));
            claims.Add(new Claim("teacherId", user.TeacherId.ToString())); // Добавляем ID преподавателя
        }
        // Если у пользователя есть связь с Admin, добавляем роль 'admin' в токен
        else if (user.AdminId.HasValue)
        {
            claims.Add(new Claim(ClaimTypes.Role, "admin"));
            claims.Add(new Claim("adminId", user.AdminId.ToString())); // Добавляем ID преподавателя
        }
        // Если у пользователя нет связи с Student или Teacher, то это обычный пользователь
        else
        {
            claims.Add(new Claim(ClaimTypes.Role, "commonuser"));
        }

        // Генерация ключа для токена
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