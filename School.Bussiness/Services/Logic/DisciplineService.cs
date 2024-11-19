using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class DisciplineService : IDisciplineService
{
    private readonly IDisciplineRepository _disciplineRepository;
    
    public DisciplineService(IDisciplineRepository disciplineRepository)
    {
        _disciplineRepository = disciplineRepository;
    }
    
    public async Task CreateDiscipline(DisciplineDto model)
    {
        var discipline = new Discipline
        {
            Name = model.Name,
            Description = model.Description,
            TeacherId = model.TeacherId
        };
        
        await _disciplineRepository.CreateDiscipline(discipline);
    }

    public async Task UpdateDiscipline(int id, DisciplineDto model)
    {
        await _disciplineRepository.UpdateDiscipline(id, model);
    }

    public async Task DeleteDiscipline(int id)
    {
        await _disciplineRepository.DeleteDiscipline(id);
    }

    public async Task<List<Discipline>> GetAllDisciplines()
    {
        return await _disciplineRepository.GetAllDisciplines();
    }
}