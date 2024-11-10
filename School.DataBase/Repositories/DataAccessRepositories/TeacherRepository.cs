using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context)
    {
        _context = context:
    }
    
    public async Task UpdateTeacher(int id, UpdateTeacherDTO model)
    {
        await _context.Teachers
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.Email, model.Email)
                .SetProperty(d => d.LastName, model.LastName)
                .SetProperty(d => d.FirstName, model.FirstName)
                .SetProperty(d => d.Patronymic, model.Patronymic)
                .SetProperty(d => d.BirthDate, model.BirthDate)
                .SetProperty(d => d.PhoneNumber, model.PhoneNumber)
                .SetProperty(d => d.PhotoPath, model.PhotoPath)
                .SetProperty(d => d.Rating, model.Rating)
                .SetProperty(d => d.Qualification, model.Qualification));
        
        
        await _context.Users
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(u => u.Email, model.Email)
                .SetProperty(u => u.PhoneNumber, model.PhoneNumber));
    }
    
    public async Task<Teacher> GetTeacher(int id)
    {
        return await _context.Teachers
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}