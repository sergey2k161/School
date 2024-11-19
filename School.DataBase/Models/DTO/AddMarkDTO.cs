namespace School.DataBase.Models.DTO;

public class AddMarkDTO
{
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public int Value { get; set; } // Оценка от 1 до 5
}
