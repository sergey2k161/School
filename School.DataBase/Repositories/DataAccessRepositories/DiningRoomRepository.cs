using Microsoft.EntityFrameworkCore;
using School.DataBase.Models.BaseModels;
using School.DataBase.Models.DTO;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Repositories.DataAccessRepositories;

public class DiningRoomRepository : IDiningRoomRepository
{
    private readonly AppDbContext _context;

    public DiningRoomRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddDish(DiningRoom diningRoom)
    {
        await _context.Dishes.AddAsync(diningRoom);
        await _context.SaveChangesAsync();
    }

    public async Task<DiningRoom?> GetDishByIdAsync(int id)
    {
        return await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateDishById(int id,DiningRoomDTO model)
    {
        // Используем ExecuteUpdateAsync для массового обновления
        await _context.Dishes
            .Where(x => x.Id == id)  // Находим нужную запись по Id
            .ExecuteUpdateAsync(x => x
                .SetProperty(d => d.Dish, model.Dish)
                .SetProperty(d => d.Weight, model.Weight)
                .SetProperty(d => d.Price, model.Price)
                .SetProperty(d => d.PhotoPath, model.PhotoPath)
                .SetProperty(d => d.Composition, model.Composition)
                .SetProperty(d => d.PFC, model.PFC)
            );
    }

    public async Task DeleteDish(int id)
    {
        await _context.Dishes.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<List<DiningRoom>> GetDishs()
    {
        return await _context.Dishes.ToListAsync();
    }
}