using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task UpdateStudent(int id, UpdateStudentDTO model)
    {
        await _context.Students
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.Email, model.Email)
                .SetProperty(d => d.LastName, model.LastName)
                .SetProperty(d => d.FirstName, model.FirstName)
                .SetProperty(d => d.Patronymic, model.Patronymic)
                .SetProperty(d => d.BirthDate, model.BirthDate)
                .SetProperty(d => d.PhoneNumber, model.PhoneNumber)
                .SetProperty(d => d.PhotoPath, model.PhotoPath)
                .SetProperty(d => d.Rating, model.Rating));
        
        await _context.Users
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(u => u.Email, model.Email)
                .SetProperty(u => u.PhoneNumber, model.PhoneNumber));
    }

    public async Task<Student> GetStudent(int id)
    {
        return await _context.Students
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}