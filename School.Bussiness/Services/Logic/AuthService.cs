using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

    public async Task<ResultDto> RegisterStudent(RegisterStudentDTO model)
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
        var student = new Student
        {
            CommonUserId = user.Id,
            Email = model.Email,
            LastName = model.LastName,
            FirstName = model.FirstName,
            Patronymic = model.Patronymic,
            BirthDate = model.BirthDate,
            ClassId = model.ClassId,
            Gender = model.Gender
        };
        
        await _authRepository.RegisterStudent(student, await _classRepository.GetClassById(model.ClassId));
        user.StudentId = student.Id;
        await _userManager.UpdateAsync(user);
        
        return new ResultDto { IsSuccess = true };
    }

    public async Task<ResultDto> RegisterTeacher(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}