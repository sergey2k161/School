using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IScheduleService
{
    Task<List<ScheduleGetDto>> GetScheduleByClassAsync(int classId);
    
    Task<List<ScheduleGetDto>> GetScheduleByTeacherAsync(int teacherId);
    
    Task<List<ScheduleGetDto>> GetScheduleByCabinetAsync(int cabinetId);
    
    Task AddScheduleAsync(ScheduleDto model);
    
    Task RemoveScheduleAsync(int id);
    
    Task UpdateScheduleAsync(int id);
    
    Task<Schedule> GetScheduleAsync(int id);
    
    Task<List<ScheduleGetDto>> GetAllSchedulesAsync();
    
    Task<List<Schedule>> GetSchedulesByStudentAsync(int studentId);
}