using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IClassService
{
    Task<CreateClassDTO> CreateClass(CreateClassDTO model);
    Task<Class?> GetClassById(int id);
    Task<List<Class>> GetAllClasses();
    Task AddStudentToClass(int classId, int studentId);
    Task DeleteStudentFromClass(int classId, int studentId);
    Task UpdateClass(Class @class);
    Task DeleteClass(int id);
}