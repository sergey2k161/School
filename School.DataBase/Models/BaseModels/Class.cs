﻿namespace School.DataBase.Models.BaseModels;

public class Class
{
    public int Id { get; set; }
    
    public string ClassNumber { get; set; } // Номер + Буква
    
    public int CountOfStudents { get; set; }
    
    public double AverageRating { get; set; }
    
    
    //public string StudentsId { get; set; }
    public List<Student> Students { get; set; }
    
    
    //public string TeacherId { get; set; }
    public List<Teacher> Teachers { get; set; }
    
    
    public string MainTeacherId { get; set; }
    public Teacher MainTeacher { get; set; }
}