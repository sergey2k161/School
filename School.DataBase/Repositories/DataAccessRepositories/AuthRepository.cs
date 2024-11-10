using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> RegisterStudent(Student student, Class @class)
    {
        var clas = await _context.Classes.FindAsync(@class.Id);
        await _context.Students.AddAsync(student);
        clas.CountOfStudents++;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RegisterTeacher(Teacher teacher)
    {
        await _context.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return true;
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
    
}