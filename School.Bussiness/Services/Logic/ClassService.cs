using Microsoft.AspNetCore.Identity;
using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }
    public async Task<CreateClassDTO> CreateClass(CreateClassDTO model)
    {
        var clas = new Class
        {
            ClassNumber = model.ClassNumber
        };
        
        await _classRepository.CreateClass(clas);
        
        return model;
    }

    public async Task<Class?> GetClassById(int id)
    {
        var clas = await _classRepository.GetClassById(id);
        return clas;
    }

    public async Task<List<Class>> GetAllClasses()
    {
        var classes = await _classRepository.GetAllClasses();
        return classes;
    }

    public async Task<ResultDto> AddStudentToClass(int classId, int studentId)
    {
        await _classRepository.AddStudentToClass(classId, studentId);
        return new ResultDto { IsSuccess = true };
    }

    public async Task<ResultDto> DeleteStudentFromClass(int classId, int studentId)
    {
        await _classRepository.DeleteStudentFromClass(classId, studentId);
        return new ResultDto { IsSuccess = true };
    }

    public async Task UpdateClass(Class @class)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteClass(int id)
    {
        throw new NotImplementedException();
    }
}