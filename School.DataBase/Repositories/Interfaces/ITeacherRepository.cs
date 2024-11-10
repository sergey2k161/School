﻿using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface ITeacherRepository
{
    Task UpdateTeacher(int id, UpdateTeacherDTO model);
    Task<Teacher> GetTeacher(int id);
}