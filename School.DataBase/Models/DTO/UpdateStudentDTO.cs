namespace School.DataBase.Models.DTO;

public class UpdateStudentDTO
{
    public string? Email { get; set; }
    
    public string? LastName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateOnly? BirthDate { get; set; }
   
    public string? PhotoPath { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public double? Rating { get; set; }
}