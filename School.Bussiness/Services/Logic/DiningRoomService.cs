using School.Bussiness.Services.Interfaces;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Services.Logic;

public class DiningRoomService : IDiningRoomService
{
    private readonly IDiningRoomRepository _diningRoomRepository;

    public DiningRoomService(IDiningRoomRepository diningRoomRepository)
    {
        _diningRoomRepository = diningRoomRepository;
    }
    public async Task<DiningRoom> CreateDish(DiningRoomDTO model)
    {
        var dish = new DiningRoom
        {
            Dish = model.Dish,
            Weight = model.Weight,
            Price = model.Price,
            PhotoPath = model.PhotoPath,
            Composition = model.Composition,
            PFC = model.PFC
        };
        
        await _diningRoomRepository.AddDish(dish);
        return dish;
    }
    

    public async Task UpdateDishById(int id, DiningRoomDTO model)
    {
        await _diningRoomRepository.UpdateDishById(id, model);
    }

    public async Task<DiningRoom> GetDishByIdAsync(int id)
    {
        return await _diningRoomRepository.GetDishByIdAsync(id);
    }

    public async Task DeleteDish(int id)
    {
        await _diningRoomRepository.DeleteDish(id);
    }

    public async Task<List<DiningRoom>> GetDishs()
    {
        return await _diningRoomRepository.GetDishs();
    }
}