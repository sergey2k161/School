using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly AppDbContext _context;

    public DisciplineRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateDiscipline(Discipline discipline)
    {
        await _context.Disciplines.AddAsync(discipline);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDiscipline(int id, DisciplineDto discipline)
    {
        await _context.Disciplines
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.Name, discipline.Name)
                .SetProperty(d => d.Description, discipline.Description));
    }

    public async Task DeleteDiscipline(int id)
    {
        await _context.Disciplines
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<List<Discipline>> GetAllDisciplines()
    {
        return await _context.Disciplines.ToListAsync();
    }
}