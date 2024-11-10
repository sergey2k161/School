using School.DataBase.Models.BaseModels;

namespace School.DataBase.Repositories.Interfaces;

public interface IClassRepository
{
    Task CreateClass(Class @class);
    Task<Class?> GetClassById(int id);
    Task<List<Class>> GetAllClasses();
    Task AddStudentToClass(int classId, int studentId);
    Task DeleteStudentFromClass(int classId, int studentId);
    Task UpdateClass(Class @class);
    Task DeleteClass(int id);
}