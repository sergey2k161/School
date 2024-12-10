namespace School.DataBase.Models.DTO;

public class ScheduleGetDto
{
    public int Id { get; set; }
    public string DayOfTheWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string CabinetName { get; set; }
    public string DisciplineName { get; set; }
}