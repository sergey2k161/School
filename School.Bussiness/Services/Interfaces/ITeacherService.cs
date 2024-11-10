using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface ITeacherService
{
    Task UpdateTeacher(int id, UpdateTeacherDTO model);
    Task<Teacher> GetTeacher(int id);
}