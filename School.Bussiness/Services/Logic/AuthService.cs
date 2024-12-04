using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.API.Controllers;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly UserManager<CommonUser> _userManager;
    private readonly IClassRepository _classRepository;

    public AuthService(IAuthRepository authRepository, UserManager<CommonUser> userManager, IClassRepository classRepository)
    {
        _authRepository = authRepository;
        _userManager = userManager;
        _classRepository = classRepository;
    }
    
    public async Task<CommonUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPasswordAsync(CommonUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<ResultDto> RegisterStudents(RegisterStudentsDTO model)
    {
        var errors = new List<string>();

        foreach (var studentModel in model.Students)
        {
            var user = new CommonUser
            {
                Email = studentModel.Email,
                UserName = studentModel.Email
            };

            var result = await _userManager.CreateAsync(user, studentModel.Password);

            if (!result.Succeeded)
            {
                // Добавляем ошибки в список
                errors.AddRange(result.Errors.Select(e => e.Description));
                continue;  // Переходим к следующему студенту
            }
            
            await _userManager.AddToRoleAsync(user, "student");
            
            var student = new Student
            {
                CommonUserId = user.Id,
                Email = studentModel.Email,
                LastName = studentModel.LastName,
                FirstName = studentModel.FirstName,
                Patronymic = studentModel.Patronymic,
                BirthDate = studentModel.BirthDate,
                ClassId = studentModel.ClassId,
                Gender = studentModel.Gender
            };

            // Регистрация студента в классе
            await _authRepository.RegisterStudent(student, await _classRepository.GetClassById(studentModel.ClassId));

            user.StudentId = student.Id;
            await _userManager.UpdateAsync(user);
        }

        // Если есть ошибки, возвращаем их
        if (errors.Any())
        {
            return new ResultDto { IsSuccess = false, Errors = errors };
        }

        return new ResultDto { IsSuccess = true };
    }


    public async Task<ResultDto> RegisterTeacher(RegisterTeacherDTO model)
    {
        var user = new CommonUser
        {
            Email = model.Email,
            UserName = model.Email
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (!result.Succeeded)
        {
            return new ResultDto { IsSuccess = false, Errors = result.Errors.Select(e => e.Description).ToList() };
        }
        
        await _userManager.AddToRoleAsync(user, "teacher");
        
        var teacher = new Teacher
        {
            CommonUserId  = user.Id,
            Email = model.Email,
            LastName = model.LastName,
            FirstName = model.FirstName,
            Patronymic = model.Patronymic
        };
        
        await _authRepository.RegisterTeacher(teacher);
        user.TeacherId = teacher.Id;
        await _userManager.UpdateAsync(user);
        
        return new ResultDto { IsSuccess = true };
    }

    public async Task<ResultDto> Login(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return new ResultDto 
            { 
                IsSuccess = false, 
                Errors = new List<string> { "Invalid login or password" }
            };
        }

        return new ResultDto 
        { 
            IsSuccess = true,
            User = user // Возвращаем информацию о пользователе для создания токена
        };
    }
    
}