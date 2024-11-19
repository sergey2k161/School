namespace School.DataBase.Models.BaseModels;

public class Schedule
{
    public int Id { get; set; } 
    
    public int ClassId { get; set; } 
    
    public Class Class { get; set; } 
    
    public int TeacherId { get; set; } 
    
    public Teacher Teacher { get; set; } 
    
    public int CabinetId { get; set; } 
    
    public Cabinet Cabinet { get; set; } 
    
    public DateTime StartTime { get; set; } 
    
    public DateTime EndTime { get; set; }
    
    public int DisciplineId { get; set; }
    
    public Discipline Discipline { get; set; }
}