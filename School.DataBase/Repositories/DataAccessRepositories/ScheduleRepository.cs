using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly AppDbContext _context;

    public ScheduleRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Schedule>> GetScheduleByClassAsync(int classId)
    {
        return await _context.Schedules
            .Where(s => s.ClassId == classId)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .ToListAsync();
    }

    public async Task<List<Schedule>> GetScheduleByTeacherAsync(int teacherId)
    {
        return await _context.Schedules 
            .Where(s => s.TeacherId == teacherId) 
            .Include(s => s.Class) 
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .ToListAsync();
    }
    

    public async Task<List<Schedule>> GetScheduleByCabinetAsync(int cabinetId)
    {
        return await _context.Schedules
            .Where(s => s.CabinetId == cabinetId)
            .Include(s => s.Class)
            .Include(s => s.Teacher)
            .Include(s => s.Discipline)
            .ToListAsync();
    }

    public async Task AddScheduleAsync(Schedule schedule)
    {
        _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveScheduleAsync(int id)
    {
        var schedule = await _context.Schedules
            .FirstOrDefaultAsync(s => s.Id == id);
        _context.Schedules.Remove(schedule);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateScheduleAsync(Schedule schedule)
    {
       await _context.Schedules
            .Where(s => s.Id == schedule.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(d => d.ClassId, schedule.ClassId)
                .SetProperty(d => d.TeacherId, schedule.TeacherId)
                .SetProperty(d => d.Cabinet, schedule.Cabinet)
                .SetProperty(d => d.StartTime, schedule.StartTime)
                .SetProperty(d => d.EndTime, schedule.EndTime));
    }

    public async Task<Schedule> GetScheduleAsync(int id)
    {
        return await _context.Schedules
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Schedule>> GetAllSchedulesAsync()
    {
        return await _context.Schedules
            .ToListAsync();
    }

    public async Task<List<Schedule>> GetSchedulesByStudentAsync(int studentId)
    {
        return await _context.Schedules
            .Where(s => s.Id == studentId)
            .Include(s => s.Cabinet)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .ToListAsync();
    }
}