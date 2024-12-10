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
        _context = context;
    }
    
    public async Task UpdateTeacher(int id, UpdateTeacherDTO model)
    {
        await _context.Teachers
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.LastName, model.LastName)
                .SetProperty(d => d.FirstName, model.FirstName)
                .SetProperty(d => d.Patronymic, model.Patronymic)
                .SetProperty(d => d.BirthDate, model.BirthDate)
                .SetProperty(d => d.PhoneNumber, model.PhoneNumber)
                .SetProperty(d => d.PhotoPath, model.PhotoPath)
                .SetProperty(d => d.Qualification, model.Qualification));
        
        
        await _context.Users
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(u => u.PhoneNumber, model.PhoneNumber));
    }
    
    public async Task<Teacher> GetTeacher(int id)
    {
        return await _context.Teachers
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task AddMark(Mark mark)
    {
        await _context.Marks.AddAsync(mark);
        await _context.SaveChangesAsync();
    }

    public async Task<Mark?> GetMarkAsync(int studentId, int teacherId)
    {
        return await _context.Marks
            .FirstOrDefaultAsync(m => m.StudentId == studentId && m.TeacherId == teacherId);
    }

    public async Task UpdateMarkAsync(Mark mark)
    {
        _context.Marks.Update(mark);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherRating(int teacherId)
    {
        // Рассчитываем средний рейтинг напрямую в базе данных
        var averageRating = await _context.Marks
            .Where(m => m.TeacherId == teacherId)
            .AverageAsync(m => (double?)m.Value) ?? 0; // Если оценок нет, рейтинг равен 0

        await _context.Teachers
            .Where(t => t.Id == teacherId)
            .ExecuteUpdateAsync(t => t.SetProperty(te => te.Rating, averageRating));
        
        await _context.SaveChangesAsync();
    }
}