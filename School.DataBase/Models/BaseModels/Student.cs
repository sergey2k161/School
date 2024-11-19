namespace School.DataBase.Models.BaseModels;

public class Student
{
    public int Id { get; set; }
    
    public int CommonUserId { get; set; }
    public CommonUser CommonUser { get; set; }
    
    public string Email { get; set; }
    
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public double? Rating { get; set; }
    
    public List<Mark> Marks { get; set; }

    public int? ClassId { get; set; }
    public Class? Class { get; set; }
    
    public string Gender { get; set; } // лучшее сделать bool, Но мне лень :))))))

    public bool Disabled { get; set; }
    
    public string? PhoneNumberForParents { get; set; }
    
    // public string MainTeacherId { get; set; }
    // public Teacher MainTeacher { get; set; }
}