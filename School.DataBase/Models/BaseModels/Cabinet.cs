namespace School.DataBase.Models.BaseModels;

public class Cabinet
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public List<Schedule> Schedules { get; set; }
    
    public List<Teacher> Teachers { get; set; }
}