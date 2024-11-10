using School.DataBase.Models.BaseModels;

namespace School.DataBase.Models;

public class Cabinet
{
    public int Id { get; set; }
    
    public string Number { get; set; }
    
    public int CountOfPlaces { get; set; }
    
    public int TeacherId { get; set; }
    public List<Teacher> Teachers { get; set; }
}
