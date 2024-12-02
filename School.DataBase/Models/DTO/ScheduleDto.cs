using System.ComponentModel;
using System.Text.Json.Serialization;

namespace School.DataBase.Models.DTO;

public class ScheduleDto
{
    public int ClassId { get; set; }
    
    public int TeacherId { get; set; }
    
    public string DayOfTheWeek { get; set; }
    
    public int CabinetId { get; set; }
    
    public int DisciplineId { get; set; }
    
    public TimeOnly StartTime { get; set; }
    
    public TimeOnly EndTime { get; set; }
    
}