using School.DataBase.Models.BaseModels;

namespace School.DataBase.Repositories.Interfaces;

public interface IDisciplineRepository
{
    Task CreateDiscipline(Discipline discipline);
    
    Task UpdateDiscipline(int id, DisciplineDto discipline);
    
    Task DeleteDiscipline(int id);

    Task<List<Discipline>> GetAllDisciplines();
}