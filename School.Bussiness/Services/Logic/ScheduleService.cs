﻿using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }
    
    public async Task<List<ScheduleGetDto>> GetScheduleByClassAsync(int classId)
    {
        var schedules = await _scheduleRepository.GetScheduleByClassAsync(classId);
        return schedules;
    }

    public async Task<List<ScheduleGetDto>> GetScheduleByTeacherAsync(int teacherId)
    {
        var schedules = await _scheduleRepository.GetScheduleByTeacherAsync(teacherId);
        return schedules;
    }
    
    public async Task<List<ScheduleGetDto>> GetSchedulesByStudentAsync(int studentId)
    {
        var schedules = await _scheduleRepository.GetSchedulesByStudentAsync(studentId);
        return schedules;
    }
    
    public async Task<List<ScheduleGetDto>> GetScheduleByCabinetAsync(int cabinetId)
    {
        var schedules = await _scheduleRepository.GetScheduleByCabinetAsync(cabinetId);
        return schedules;
    }

    public async Task AddScheduleAsync(ScheduleDto model)
    {
        var schedule = new Schedule
        {
            ClassId = model.ClassId,
            TeacherId = model.TeacherId,
            DayOfTheWeek = model.DayOfTheWeek,
            CabinetId = model.CabinetId,
            DisciplineId = model.DisciplineId,
            StartTime = model.StartTime,
            EndTime = model.EndTime
        };
        
        await _scheduleRepository.AddScheduleAsync(schedule);
    }

    public async Task RemoveScheduleAsync(int id)
    {
        await _scheduleRepository.RemoveScheduleAsync(id);
    }

    public async Task UpdateScheduleAsync(int id, ScheduleGetDto updatedScheduleDto)
    {
        await _scheduleRepository.UpdateScheduleAsync(updatedScheduleDto);
    }

    public async Task<ScheduleGetDto> GetScheduleAsync(int id)
    {
        var schedule = await _scheduleRepository.GetScheduleAsync(id);
        return schedule;
    }

    public async Task<List<ScheduleGetDto>> GetAllSchedulesAsync()
    {
        var schedules = await _scheduleRepository.GetAllSchedulesAsync();
        return schedules;
    }

    
}