namespace School.DataBase.Repositories.Interfaces;

public class DisciplineDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int? TeacherId { get; set; }
}