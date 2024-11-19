namespace School.DataBase.Models.DTO;

public class ScheduleDto
{
    public int ClassId { get; set; }
    
    public int TeacherId { get; set; }
    
    public int CabinetId { get; set; }
    
    public int DisciplineId { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
}