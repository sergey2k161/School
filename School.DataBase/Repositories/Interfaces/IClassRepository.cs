using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface IClassRepository
{
    Task CreateClass(Class @class);
    Task<ClassGetDto?> GetClassById(int id);
    Task<List<ClassGetDto>?> GetAllClasses();
    Task AddStudentToClass(int classId, int studentId);
    Task DeleteStudentFromClass(int classId, int studentId);
    Task UpdateMainTeacher(int classId, int teacherId);
    Task UpdateClass(Class @class);
    Task DeleteClass(int id);
}