using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task UpdateStudent(int id, UpdateStudentDTO model)
    {
        await _studentRepository.UpdateStudent(id, model);
    }

    public async Task<Student> GetStudent(int id)
    {
        return await _studentRepository.GetStudent(id);
    }
}