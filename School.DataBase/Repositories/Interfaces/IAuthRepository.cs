using School.DataBase.Models.BaseModels;

namespace School.DataBase.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<bool> RegisterStudent(Student student);
    Task<bool> RegisterTeacher(Teacher teacher);
}