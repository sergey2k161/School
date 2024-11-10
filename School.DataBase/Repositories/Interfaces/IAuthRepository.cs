using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<bool> RegisterStudent(Student student, Class @class);
    Task<bool> RegisterTeacher(Teacher teacher);
    Task UpdateStudent(int id, UpdateStudentDTO model);
    Task UpdateTeacher(int id, UpdateTeacherDTO model);

}