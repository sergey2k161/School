namespace School.DataBase.Models.BaseModels;

public class DiningRoom
{
    public int Id { get; set; }
    
    public string Dish { get; set; }
    
    public double Weight { get; set; }
    
    public double Price { get; set; }
    
    public string PhotoPath { get; set; }
    
    public string Composition { get; set; }
    
    public string PFC { get; set; } // БЖУ
}