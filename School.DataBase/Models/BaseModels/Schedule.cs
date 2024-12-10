namespace School.DataBase.Models.BaseModels;

public class Schedule
{
    public int Id { get; set; } 
    
    public int ClassId { get; set; } 
    
    public Class Class { get; set; } 
    
    public int TeacherId { get; set; } 
    
    public Teacher Teacher { get; set; } 
    
    public string DayOfTheWeek { get; set; }
    public int CabinetId { get; set; } 
    public string CabinetName { get; set; }
    
    public Cabinet Cabinet { get; set; } 
    
    public TimeOnly StartTime { get; set; } 
    
    public TimeOnly EndTime { get; set; }
    
    public int DisciplineId { get; set; }
    
    public Discipline Discipline { get; set; }
}