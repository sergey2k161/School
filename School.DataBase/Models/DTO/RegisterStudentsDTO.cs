namespace School.DataBase.Models.DTO;

// Новый DTO для нескольких студентов
public class RegisterStudentsDTO
{
    public List<RegisterStudentDTO> Students { get; set; }
}