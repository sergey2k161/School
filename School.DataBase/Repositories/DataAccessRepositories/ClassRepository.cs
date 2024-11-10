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
            .Include(c => c.Students) // Загрузка связанных студентов
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Class>> GetAllClasses()
    {
        return await _context.Classes.ToListAsync();
    }

    public async Task AddStudentToClass(int classId, int studentId)
    {
        var newClass = await _context.Classes.Include(c => c.Students)
            .FirstOrDefaultAsync(x => x.Id == classId);
        if (newClass == null)
        {
            throw new Exception("Class not found");
        }
        
        var student = await _context.Students.Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == studentId);
        if (student == null)
        {
            throw new Exception("Student not found");
        }
        
        if (student.Class != null)
        {
            var currentClass = student.Class;
            currentClass.Students.Remove(student);
            currentClass.CountOfStudents--;

            _context.Classes.Update(currentClass);
        }
        
        newClass.Students.Add(student);
        newClass.CountOfStudents++;

        student.ClassId = classId;
        
        _context.Students.Update(student);
        _context.Classes.Update(newClass);
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