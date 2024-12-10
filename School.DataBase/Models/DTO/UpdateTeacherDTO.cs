namespace School.DataBase.Models.DTO;

public class UpdateTeacherDTO
{
    public string? LastName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Qualification { get; set; }
}