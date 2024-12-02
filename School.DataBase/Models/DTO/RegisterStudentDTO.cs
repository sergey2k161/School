﻿namespace School.DataBase.Models.DTO;

public class RegisterStudentDTO
{
    public string Email { get; set; }
    
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string Patronymic { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public int ClassId { get; set; }
    
    public string Gender { get; set; }
    
    public string Password { get; set; }
    
    // Новый DTO для нескольких студентов
    public class RegisterStudentsDTO
    {
        public List<RegisterStudentDTO> Students { get; set; }
    }
}