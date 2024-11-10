using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> RegisterStudent(Student student)
    {
        await _context.AddAsync(student);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RegisterTeacher(Teacher teacher)
    {
        await _context.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return true;
    }
}