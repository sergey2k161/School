using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class ScheduleRepository : IScheduleRepository
{
    private readonly AppDbContext _context;

    public ScheduleRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ScheduleGetDto>> GetScheduleByClassAsync(int classId)
    {
        return await _context.Schedules
            .Where(s => s.ClassId == classId)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
            .ToListAsync();
    }

    public async Task<List<ScheduleGetDto>> GetScheduleByTeacherAsync(int teacherId)
    {
        return await _context.Schedules
            .Where(s => s.TeacherId == teacherId)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassId = s.ClassId,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherId = s.TeacherId,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
            .ToListAsync();
    }
    
    public async Task<List<ScheduleGetDto>> GetScheduleByCabinetAsync(int cabinetId)
    {
        return await _context.Schedules
            .Where(s => s.CabinetId == cabinetId)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassId = s.ClassId,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherId = s.TeacherId,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
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

    public async Task UpdateScheduleAsync(ScheduleGetDto schedule)
    {
       await _context.Schedules
            .Where(s => s.Id == schedule.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(d => d.ClassId, schedule.ClassId)
                .SetProperty(d => d.TeacherId, schedule.TeacherId)
                .SetProperty(d => d.DayOfTheWeek, schedule.DayOfTheWeek)
                .SetProperty(d => d.CabinetName, schedule.CabinetName)
                .SetProperty(d => d.StartTime, schedule.StartTime)
                .SetProperty(d => d.EndTime, schedule.EndTime));
    }

    public async Task<ScheduleGetDto> GetScheduleAsync(int id)
    {
        // return await _context.Schedules
        //     .FirstOrDefaultAsync(s => s.Id == id);
        
        return await _context.Schedules
            .Where(s => s.Id == id)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassId = s.ClassId,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherId = s.TeacherId,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
            .SingleOrDefaultAsync();
    }

    public async Task<List<ScheduleGetDto>> GetAllSchedulesAsync()
    {
        return await _context.Schedules
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassId = s.ClassId,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherId = s.TeacherId,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
            .ToListAsync();
    }

    public async Task<List<ScheduleGetDto>> GetSchedulesByStudentAsync(int studentId)
    {
        return await _context.Schedules
            .Where(s => s.Id == studentId)
            .Include(s => s.Teacher)
            .Include(s => s.Cabinet)
            .Include(s => s.Discipline)
            .Include(s => s.Class)
            .Select(s => new ScheduleGetDto
            {
                Id = s.Id,
                DayOfTheWeek = s.DayOfTheWeek,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                ClassId = s.ClassId,
                ClassName = s.Class != null ? s.Class.ClassNumber : null,
                TeacherId = s.TeacherId,
                TeacherName = s.Teacher != null ? $"{s.Teacher.LastName} {s.Teacher.FirstName} {s.Teacher.Patronymic}" : null,
                CabinetName = s.Cabinet != null ? s.Cabinet.Name : null,
                DisciplineName = s.Discipline != null ? s.Discipline.Name : null
            })
            .ToListAsync();
    }
}