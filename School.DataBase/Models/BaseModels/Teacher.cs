namespace School.DataBase.Models.BaseModels;

public class Teacher
{
    public int Id { get; set; }
    
    public int CommonUserId { get; set; }
    public CommonUser CommonUser { get; set; }
    
    public string? LastName { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? Patronymic { get; set; }
    
    public DateOnly BirthDate { get; set; }
    
    public string? PhotoPath { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }
    
    public double? Rating { get; set; }
    
    // Рабочая информация
    
    //public string DisciplineId { get; set; }
    public List<Discipline?> Disciplines { get; set; } = [];
    
    
    //public string ClassId { get; set; }
    public List<Class?> Classes { get; set; } = [];
    public Class? MainClass { get; set; } // КЛ руковод
    
    //public string CabinetId { get; set; }
    public List<Cabinet?> Cabinets { get; set; } = [];
    
    
    // public string MainStudentId { get; set; }
    // public List<Student> MainStudents { get; set; }
    
    public string? Qualification { get; set; }
}