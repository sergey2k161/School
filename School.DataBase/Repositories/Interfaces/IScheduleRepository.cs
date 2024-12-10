using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface IScheduleRepository
{
    Task<List<ScheduleGetDto>> GetScheduleByClassAsync(int classId);
    
    Task<List<ScheduleGetDto>> GetScheduleByTeacherAsync(int teacherId);
    
    Task<List<ScheduleGetDto>> GetScheduleByCabinetAsync(int cabinetId);
    
    Task AddScheduleAsync(Schedule schedule);
    
    Task RemoveScheduleAsync(int id);
    
    Task UpdateScheduleAsync(ScheduleGetDto schedule);
    
    Task<ScheduleGetDto> GetScheduleAsync(int id);
    
    Task<List<ScheduleGetDto>> GetAllSchedulesAsync();
    
    Task<List<ScheduleGetDto>> GetSchedulesByStudentAsync(int studentId);
}