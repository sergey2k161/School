using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class ClassRepository : IClassRepository
{
    private readonly AppDbContext _context;

    public ClassRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateClass(Class @class)
    {
        await _context.Classes.AddAsync(@class);
        await _context.SaveChangesAsync();
    }

    public async Task<Class?> GetClassById(int id)
    {
        return await _context.Classes
            .Include(c => c.Students)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Class>> GetAllClasses()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task AddStudentToClass(int classId, int studentId)
    {
        var clas = await _context.Classes.FirstOrDefaultAsync(x => x.Id == classId);
        
        var student = await _context.Students.FindAsync(studentId);
        
        clas.Students.Add(student);
        clas.CountOfStudents++;
        
        student.ClassId = classId;
        
        await _context.SaveChangesAsync();
    }


    public async Task DeleteStudentFromClass(int classId, int studentId)
    {
        var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == studentId);
        var clas = await _context.Classes.FirstOrDefaultAsync(x => x.Id == classId);    
        if (student.ClassId == classId)
        {
            clas.CountOfStudents--;
            await _context.SaveChangesAsync();
            
            student.ClassId = 0;
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateClass(Class @class)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteClass(int id)
    {
        await _context.Classes.Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}