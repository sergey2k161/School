using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    
    public async Task UpdateTeacher(int id, UpdateTeacherDTO model)
    {
        await _teacherRepository.UpdateTeacher(id, model);
    }
    
    public async Task<Teacher> GetTeacher(int id)
    {
        return await _teacherRepository.GetTeacher(id);
    }
}