using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IStudentService
{
    Task UpdateStudent(int id, UpdateStudentDTO model);
    Task<Student> GetStudent(int id);

}