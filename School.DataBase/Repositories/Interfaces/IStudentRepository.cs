using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface IStudentRepository
{
    Task UpdateStudent(int id, UpdateStudentDTO model);
    Task<Student> GetStudent(int id);
    
    Task UpdateStudentRating(int studentId);

    Task AddMark(Mark mark);
}