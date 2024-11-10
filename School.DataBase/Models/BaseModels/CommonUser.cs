using Microsoft.AspNetCore.Identity;

namespace School.DataBase.Models.BaseModels;

public class CommonUser : IdentityUser<int>
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    
    public int StudentId { get; set; }
    public Student Student { get; set; }
    
    public string Employees { get; set; }
    public double Salary { get; set; }
    public DateOnly AcceptedDate { get; set; }
}