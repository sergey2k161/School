namespace School.DataBase.Models.DTO;

public class ClassGetDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int CountOfStudents { get; set; }
    
    public int? MainTeacherId { get; set; }
    
    public string MainTeacherName { get; set; }
    
    public List<StudentDto> Students { get; set; }
}