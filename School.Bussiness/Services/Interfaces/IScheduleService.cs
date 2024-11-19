using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IScheduleService
{
    Task<List<Schedule>> GetScheduleByClassAsync(int classId);
    
    Task<List<Schedule>> GetScheduleByTeacherAsync(int teacherId);
    
    Task<List<Schedule>> GetScheduleByCabinetAsync(int cabinetId);
    
    Task AddScheduleAsync(ScheduleDto model);
    
    Task RemoveScheduleAsync(int id);
    
    Task UpdateScheduleAsync(int id);
    
    Task<Schedule> GetScheduleAsync(int id);
    
    Task<List<Schedule>> GetAllSchedulesAsync();
    
    Task<List<Schedule>> GetSchedulesByStudentAsync(int studentId);
}