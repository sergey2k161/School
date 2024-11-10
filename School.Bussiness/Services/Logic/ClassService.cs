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
        throw new NotImplementedException();
    }

    public async Task<List<Class>> GetAllClasses()
    {
        throw new NotImplementedException();
    }

    public async Task AddStudentToClass(int classId, int studentId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteStudentFromClass(int classId, int studentId)
    {
        throw new NotImplementedException();
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