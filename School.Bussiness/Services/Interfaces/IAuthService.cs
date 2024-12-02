using School.API.Controllers;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IAuthService
{
    Task<CommonUser?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(CommonUser user, string password);
    Task<ResultDto> RegisterStudents(RegisterStudentsDTO student);
    Task<ResultDto> RegisterTeacher(RegisterTeacherDTO teacher);
    Task<ResultDto> Login(LoginModel model);
    
}