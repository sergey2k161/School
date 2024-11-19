using School.DataBase.Models.BaseModels;

namespace School.DataBase.Repositories.Interfaces;

public interface IScheduleRepository
{
    Task<List<Schedule>> GetScheduleByClassAsync(int classId);
    
    Task<List<Schedule>> GetScheduleByTeacherAsync(int teacherId);
    
    Task<List<Schedule>> GetScheduleByCabinetAsync(int cabinetId);
    
    Task AddScheduleAsync(Schedule schedule);
    
    Task RemoveScheduleAsync(int id);
    
    Task UpdateScheduleAsync(Schedule schedule);
    
    Task<Schedule> GetScheduleAsync(int id);
    
    Task<List<Schedule>> GetAllSchedulesAsync();
    
    Task<List<Schedule>> GetSchedulesByStudentAsync(int studentId);
}