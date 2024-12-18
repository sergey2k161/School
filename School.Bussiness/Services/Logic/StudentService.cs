﻿using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ITeacherRepository _teacherRepository;

    public StudentService(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
    {
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
    }
    
    public async Task UpdateStudent(int id, UpdateStudentDTO model)
    {
        await _studentRepository.UpdateStudent(id, model);
    }

    public async Task<Student> GetStudent(int id)
    {
        return await _studentRepository.GetStudent(id);
    }

    public async Task AddMark(AddMarkDTO model)
    {
        var student = await _studentRepository.GetStudent(model.StudentId);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {model.StudentId} not found.");
        }
        
        // Проверяем, существует ли учитель
        var teacher = await _teacherRepository.GetTeacher(model.TeacherId);
        if (teacher == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {model.TeacherId} not found.");
        }
        // Проверяем диапазон оценки
        if (model.Value < 1 || model.Value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(model.Value), "Mark value must be between 1 and 5.");
        }

        // Проверяем существующую оценку
        var existingMark = await _studentRepository.GetMarkAsync(model.StudentId, model.TeacherId);

        if (existingMark != null)
        {
            // Если оценка существует, обновляем её значение
            existingMark.Value = model.Value;
            await _studentRepository.UpdateMarkAsync(existingMark);
        }
        else
        {
            // Если оценки нет, создаем новую
            var mark = new Mark
            {
                StudentId = model.StudentId,
                TeacherId = model.TeacherId,
                Value = model.Value
            };
            await _studentRepository.AddMark(mark);
        }
        
        // Обновляем рейтинг ученика
        await _studentRepository.UpdateStudentRating(model.StudentId);
    }

    public async Task<Mark?> GetMarkAsync(int studentId, int teacherId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateMark(Mark model)
    {
        throw new NotImplementedException();
    }
}