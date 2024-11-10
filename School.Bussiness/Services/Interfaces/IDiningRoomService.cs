using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;

namespace School.Bussiness.Services.Interfaces;

public interface IDiningRoomService
{
    Task<DiningRoom> CreateDish(DiningRoomDTO model);
    Task UpdateDishById(int id, DiningRoomDTO model);
    Task<DiningRoom> GetDishByIdAsync(int id);
    Task DeleteDish(int id);
    Task<List<DiningRoom>> GetDishs();
}