using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Interfaces;

public interface IDisciplineService
{
    Task CreateDiscipline(DisciplineDto model);
    
    Task UpdateDiscipline(int id, DisciplineDto model);
    
    Task DeleteDiscipline(int id);
    
    Task<List<Discipline>> GetAllDisciplines();
}