namespace School.DataBase.Models.BaseModels;

public class Admin
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public int CommonUserId { get; set; }
    public CommonUser CommonUser { get; set; }
}