using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class TeacherService : ITeacherService
{
    private readonly IStudentRepository _studentRepository;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
    {
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
    }
    
    public async Task UpdateTeacher(int id, UpdateTeacherDTO model)
    {
        await _teacherRepository.UpdateTeacher(id, model);
    }
    
    public async Task<Teacher> GetTeacher(int id)
    {
        return await _teacherRepository.GetTeacher(id);
    }
    
    public async Task AddMark(AddMarkDTO model)
    {
        // Проверяем, существует ли учитель
        var teacher = await _teacherRepository.GetTeacher(model.TeacherId);
        if (teacher == null)
        {
            throw new KeyNotFoundException($"Teacher with ID {model.TeacherId} not found.");
        }
        
        var student = await _studentRepository.GetStudent(model.StudentId);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {model.StudentId} not found.");
        }
        
        // Проверяем диапазон оценки
        if (model.Value < 1 || model.Value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(model.Value), "Mark value must be between 1 and 5.");
        }

        // Проверяем существующую оценку
        var existingMark = await _teacherRepository.GetMarkAsync(model.StudentId, model.TeacherId);
        if (existingMark != null)
        {
            // Если оценка существует, обновляем её значение
            existingMark.Value = model.Value;
            await _teacherRepository.UpdateMarkAsync(existingMark);
        }
        else
        {
            // Создаем новую оценку
            var mark = new Mark
            {
                StudentId = model.StudentId,
                TeacherId = model.TeacherId,
                Value = model.Value
            };
            await _teacherRepository.AddMark(mark);
        }
        
        // Обновляем рейтинг ученика
        await _teacherRepository.UpdateTeacherRating(model.StudentId);
    }
}