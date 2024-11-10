using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.DataBase.Repositories.Interfaces;

public interface IDiningRoomRepository
{
    Task AddDish(DiningRoom diningRoom);
    Task UpdateDishById(int id,DiningRoomDTO model);
    Task<DiningRoom?> GetDishByIdAsync(int id);
    Task DeleteDish(int id);
    Task<List<DiningRoom>> GetDishs();
}